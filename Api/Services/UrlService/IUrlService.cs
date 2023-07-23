using Api.Data;

namespace Api.Services.UrlService;

public interface IUrlService
{
    Task<IEnumerable<Url>> GetUrls();
    Task<IEnumerable<Url>> AddUrl(Url url);
    Task<IEnumerable<Url>> RemoveUrl(int id);
    Task<Url> GetUrl(int id);
}
