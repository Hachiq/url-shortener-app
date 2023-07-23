using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.UrlService
{
    public class UrlService : IUrlService
    {
        private readonly AppDbContext _db;

        public UrlService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Url>> GetUrls()
        {
            return await _db.URLs.ToListAsync();
        }

        public async Task<IEnumerable<Url>> AddUrl(Url url)
        {
            _db.URLs.Add(url);
            await _db.SaveChangesAsync();
            return await _db.URLs.ToListAsync();
        }

        public async Task<IEnumerable<Url>> RemoveUrl(int id)
        {
            var url = await _db.URLs.FindAsync(id);
            if (url is null)
            {
                return await _db.URLs.ToListAsync();
            }
            _db.URLs.Remove(url);
            await _db.SaveChangesAsync();
            return await _db.URLs.ToListAsync();
        }

        public async Task<Url> GetUrl(int id)
        {
            return await _db.URLs.FirstAsync(x => x.Id == id);
        }
    }
}
