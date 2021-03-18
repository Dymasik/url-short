namespace UrlShort.Services {
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UrlShort.Models;

    public interface IUrlService {
        Task<string> CreateShortUrl(string baseUrl);
        Task<IEnumerable<Url>> GetUrls();
        Task<string> GetFullUrl(Guid id);
    }
}
