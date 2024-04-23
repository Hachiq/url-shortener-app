using Api.DTOs;
using Api.Mappers;
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
        private readonly UrlMapper _mapper;

        public UrlController(IUrlRepository urlRepository, IUrlService urlService, IUserRepository userRepository, UrlMapper mapper)
        {
            _urlRepository = urlRepository;
            _urlService = urlService;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<ShortenedUrl>>> Get()
        {
            return Ok(_mapper.MapUrlListToDtoList(await _urlRepository.GetAllAsync()));
        }

        [HttpPost("shorten")]
        public async Task<ActionResult> ShortenUrl(UrlShorteningRequestDto request)
        {
            if (!Uri.TryCreate(request.Url, UriKind.Absolute, out _))
            {
                return BadRequest(new { message = "The specified URL is invalid.", reason = "InvalidUrl" });
            }

            string code = await _urlService.GenerateUniqueCode();

            var creator = await _userRepository.GetUserByUsernameAsync(request.Username);
            if (creator is null)
            {
                return BadRequest(new { message = "Creator not specified.", reason = "NoCreator" });
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
