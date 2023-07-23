using Api.Data;
using Api.Services.UrlService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IUrlService _urlService;

        public UrlController(IUrlService urlService)
        {
            _urlService = urlService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Url>>> Get()
        {
            return Ok(await _urlService.GetUrls());
        }

        [HttpPost]
        public async Task<ActionResult> Add(Url url)
        {
            await _urlService.AddUrl(url);
            return Ok(await _urlService.GetUrls());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _urlService.RemoveUrl(id);
            return Ok(await _urlService.GetUrls());
        }

        [HttpGet("{id}")]
        public async Task<Url> Get(int id)
        {
            return await _urlService.GetUrl(id);
        }
    }
}
