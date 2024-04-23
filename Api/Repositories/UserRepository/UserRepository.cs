using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _db.Users.SingleOrDefaultAsync(u => u.Username == username);
        }

        public async Task AddUserAsync(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.UserRoles.AddAsync(new UserRole
            {
                UserId = user.Id,
                RoleId = 1
            });
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<string>> GetUserRolesByUserIdAsync(Guid id)
        {
            var user = await _db.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Id == id);

            return user?.UserRoles.Select(ur => ur.Role.Name) ?? Enumerable.Empty<string>();
        }
    }
}
