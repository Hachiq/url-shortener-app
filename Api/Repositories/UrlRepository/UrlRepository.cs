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
            return await _db.ShortenedUrls.ToListAsync();
        }

        public async Task AddAsync(ShortenedUrl shortenedUrl)
        {
            await _db.ShortenedUrls.AddAsync(shortenedUrl);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> CodeIsUnique(string code)
        {
            return !await _db.ShortenedUrls.AnyAsync(s => s.Code == code);
        }
    }
}
