using Api.Models;

namespace Api.Services.AuthService
{
    public interface IAuthService
    {
        string CreateToken(User user);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        bool IsValidUsername(string username);
        bool IsValidPassword(string password);
    }
}
