using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.UrlRepository
{
    public class UrlRepository : IUrlRepository
    {
        private readonly AppDbContext _db;

        public UrlRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<ShortenedUrl>> GetAllAsync()
        {
            return await _db.ShortenedUrls.Include(u => u.Creator).ToListAsync();
        }

        public async Task AddAsync(ShortenedUrl shortenedUrl)
        {
            await _db.ShortenedUrls.AddAsync(shortenedUrl);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(ShortenedUrl shortenedUrl)
        {
            _db.ShortenedUrls.Remove(shortenedUrl);
            await _db.SaveChangesAsync();
        }

        public async Task<ShortenedUrl> FindByIdAsync(string id)
        {
            return await _db.ShortenedUrls.FirstOrDefaultAsync(u => u.Id == Guid.Parse(id));
        }

        public async Task<ShortenedUrl> FindByShortUrlAsync(string url)
        {
            return await _db.ShortenedUrls.FirstOrDefaultAsync(u => u.ShortUrl == url);
        }

        public async Task<bool> UrlIsUnique(string url)
        {
            return !await _db.ShortenedUrls.AnyAsync(s => s.LongUrl == url);
        }

        public async Task<bool> CodeIsUnique(string code)
        {
            return !await _db.ShortenedUrls.AnyAsync(s => s.Code == code);
        }
    }
}
