using Api.Models;

namespace Api.Repositories.UrlRepository
{
    public interface IUrlRepository
    {
        Task<List<ShortenedUrl>> GetAllAsync();
        Task AddAsync(ShortenedUrl shortenedUrl);
        Task<bool> UrlIsUnique(string url);
        Task<bool> CodeIsUnique(string code);
    }
}
