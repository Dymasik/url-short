namespace UrlShort.Controllers {
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using UrlShort.Models;
    using UrlShort.Services;

    [ApiController]
    [Route("api/url")]
    public class UrlController : ControllerBase {
        private readonly IUrlService _urlService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<UrlController> _logger;

        public UrlController(IUrlService urlService, IHttpContextAccessor httpContextAccessor, ILogger<UrlController> logger) {
            _urlService = urlService;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        [HttpPost]
        public async Task<UrlCreationResponse> CreateShortUrl(string url) {
            var response = new UrlCreationResponse {
                Success = true
            };
            try {
                var id = await _urlService.CreateShortUrl(url);
                response.ShortUrl = $"{_httpContextAccessor.HttpContext.Request.Host.Value}/{id}";
                _logger.LogInformation($"Successfully create short url: {response.ShortUrl}");
            } catch (Exception ex) {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                _logger.LogError($"Error occured while create short url: {response.ErrorMessage} with stack trace: {ex.StackTrace}");
            }
            return response;
        }

        [HttpGet]
        public async Task<GetUrlsResponse> GetUrls() {
            var response = new GetUrlsResponse {
                Success = true
            };
            try {
                var urls = await _urlService.GetUrls();
                response.Urls = urls.Select(u => new UrlDto { 
                    Url = u.FullPath,
                    ShortUrl = $"{_httpContextAccessor.HttpContext.Request.Host.Value}/{u.Id}"
                });
                _logger.LogInformation($"Successfully get urls");
            } catch (Exception ex) {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                _logger.LogError($"Error occured while get all urls: {response.ErrorMessage} with stack trace: {ex.StackTrace}");
            }
            return response;
        }
    }
}
