namespace Api.DTOs
{
    public class ShortenedUrlDto
    {
        public string Id { get; set; }
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
        public string Creator { get; set; }
    }
}
