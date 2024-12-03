using Building_Construction_Management_System.Data;
using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Building_Construction_Management_System.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly BuildingConstructionDbContext _context;

        public UserRepository(BuildingConstructionDbContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task AddUserAsync(User user)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC AddUser @Username={user.Username}, @PasswordHash={user.PasswordHash}, @Role={user.Role}, @Email={user.Email}, @PhoneNumber={user.PhoneNumber}, @IsActive={user.IsActive}");
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async System.Threading.Tasks.Task UpdateUserAsync(User user)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC UpdateUser @UserId={user.UserId}, @Username={user.Username}, @Role={user.Role}, @Email={user.Email}, @PhoneNumber={user.PhoneNumber}, @IsActive={user.IsActive}");
        }
    }
}
