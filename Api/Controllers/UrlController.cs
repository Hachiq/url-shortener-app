using Api.DTOs;
using Api.Models;
using Api.Repositories.UrlRepository;
using Api.Repositories.UserRepository;
using Api.Services.UrlService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IUrlRepository _urlRepository;
        private readonly IUrlService _urlService;
        private readonly IUserRepository _userRepository;

        public UrlController(IUrlRepository urlRepository, IUrlService urlService, IUserRepository userRepository)
        {
            _urlRepository = urlRepository;
            _urlService = urlService;
            _userRepository = userRepository;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<ShortenedUrl>>> Get()
        {
            return Ok(await _urlRepository.GetAllAsync());
        }

        [HttpPost("shorten")]
        public async Task<ActionResult> ShortenUrl(UrlShorteningRequestDto request)
        {
            if (!Uri.TryCreate(request.Url, UriKind.Absolute, out _))
            {
                return BadRequest("The specified URL is invalid.");
            }

            string code = await _urlService.GenerateUniqueCode();

            var creator = await _userRepository.GetUserByUsernameAsync(request.Username);
            if (creator is null)
            {
                return BadRequest("Creator not specified.");
            }

            var httpRequest = HttpContext.Request;

            var shortenedUrl = new ShortenedUrl
            {
                Id = Guid.NewGuid(),
                LongUrl = request.Url,
                ShortUrl = $"{httpRequest.Scheme}://{httpRequest.Host}/{code}",
                Code = code,
                Creator = creator,
                CreatedOn = DateTime.Now
            };

            await _urlRepository.AddAsync(shortenedUrl);

            return Ok(shortenedUrl.ShortUrl);
        }
    }
}
