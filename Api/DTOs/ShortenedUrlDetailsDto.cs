using Api.Models;

namespace Api.DTOs
{
    public class ShortenedUrlDetailsDto
    {
        public string Id { get; set; }
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
        public string Code { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
