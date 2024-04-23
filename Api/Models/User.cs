using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
