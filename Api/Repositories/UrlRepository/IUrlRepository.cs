using Api.Models;

namespace Api.Repositories.UrlRepository
{
    public interface IUrlRepository
    {
        Task<List<ShortenedUrl>> GetAllAsync();
        Task AddAsync(ShortenedUrl shortenedUrl);
        Task<bool> CodeIsUnique(string code);
    }
}
