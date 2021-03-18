namespace UrlShort.Services {
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UrlShort.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    public class UrlService : IUrlService {
        private readonly UrlContext _context;

        public UrlService(UrlContext context) {
            _context = context;
        }

        private async Task SaveChanges() {
            await _context.SaveChangesAsync();
        }

        public async Task<string> CreateShortUrl(string baseUrl) {
            var url = new Url {
                FullPath = baseUrl
            };
            _context.Urls.Add(url);
            await SaveChanges();
            return url.Id.ToString();
        }

        public async Task<IEnumerable<Url>> GetUrls() {
            return await _context.Urls.ToListAsync();
        }

        public async Task<string> GetFullUrl(Guid id) {
            var url = await _context.Urls
                .SingleAsync(u => u.Id == id);
            return url.FullPath;
        }
    }
}
