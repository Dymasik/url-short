namespace UrlShort.Controllers {
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using UrlShort.Services;

    [Route("")]
    [ApiController]
    public class UrlRedirectController : ControllerBase {
        private readonly IUrlService _urlService;

        public UrlRedirectController(IUrlService urlService) {
            _urlService = urlService;
        }

        [HttpGet("{urlId}")]
        public async Task<ActionResult> RedirectByShortUrl(Guid urlId) {
            var url = await _urlService.GetFullUrl(urlId);
            return Redirect(url);
        }
    }
}
