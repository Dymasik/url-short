namespace UrlShort.Models {
    using System.Collections.Generic;

    public abstract class BaseResponse {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class UrlCreationResponse : BaseResponse {
        public string ShortUrl { get; set; }
    }

    public class GetUrlsResponse : BaseResponse {
        public IEnumerable<UrlDto> Urls { get; set; }
    }

    public class UrlDto {
        public string Url { get; set; }
        public string ShortUrl { get; set; }
    }
}
