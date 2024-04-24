using Api.Models;

namespace Api.Repositories.UrlRepository
{
    public interface IUrlRepository
    {
        Task<List<ShortenedUrl>> GetAllAsync();
        Task AddAsync(ShortenedUrl shortenedUrl);
        Task DeleteAsync(ShortenedUrl shortenedUrl);
        Task<ShortenedUrl> FindByIdAsync(string id);
        Task<ShortenedUrl> FindByShortUrlAsync(string url);
        Task<bool> UrlIsUnique(string url);
        Task<bool> CodeIsUnique(string code);
    }
}
