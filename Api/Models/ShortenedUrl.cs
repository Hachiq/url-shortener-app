using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class ShortenedUrl
    {
        public Guid Id { get; set; }
        [Required]
        public string LongUrl { get; set; } = string.Empty;
        [Required]
        public string ShortUrl { get; set; } = string.Empty;
        [Required]
        public string Code { get; set; } = string.Empty;
        public User Creator { get; set; } = null!;
        public DateTime CreatedOn { get; set; }

    }
}
