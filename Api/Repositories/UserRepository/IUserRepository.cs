using Api.Models;

namespace Api.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task AddUserAsync(User user);
        Task<IEnumerable<string>> GetUserRolesByUserIdAsync(Guid id);
    }
}
