using System.ComponentModel.DataAnnotations;

namespace Api.Data
{
    public class Url
    {
        [Key]
        public int Id { get; set; }
        public string LongUrl { get; set; } = string.Empty;
        public string ShortUrl { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
