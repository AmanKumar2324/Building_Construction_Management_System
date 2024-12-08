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

        //public async System.Threading.Tasks.Task AddUserAsync(User user)
        //{
        //    await _context.Database.ExecuteSqlInterpolatedAsync(
        //        $"EXEC AddUser @Username={user.Username}, @PasswordHash={user.PasswordHash}, @Role={user.Role}, @Email={user.Email}, @PhoneNumber={user.PhoneNumber}, @IsActive={user.IsActive}");
        //}

        public async System.Threading.Tasks.Task AddUserAsync(User user)
        {
            // Generate Custom User ID
            user.RoleUserId = await GenerateCustomUserIdAsync(user.Role);

            // Add User to Database
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        private async Task<string> GenerateCustomUserIdAsync(string role)
        {
            // Determine Prefix Based on Role
            string prefix = role switch
            {
                "Admin" => "ADMIN",
                "Project Manager" => "PM",
                "Architect" => "ARCH",
                "Engineer" => "ENG",
                "Site Supervisor" => "SS",
                "Worker" => "W",
                "Supplier" => "SUP",
                _ => throw new ArgumentException("Invalid role")
            };

            // Count Existing Users with the Same Role Prefix
            int count = await _context.Users.CountAsync(u => u.RoleUserId.StartsWith(prefix));

            // Generate Custom ID (e.g., PM001, ADMIN002)
            return $"{prefix}{(count + 1):D3}";
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
        public async System.Threading.Tasks.Task DeleteUserAsync(int userId)
        {
            // Using the stored procedure for deleting the user
            await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC DeleteUser @UserId={userId}");
        }
        public async Task<User> GetUserByRoleUserIdAsync(string roleUserId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.RoleUserId == roleUserId);
        }
        public async Task<User> AuthenticateUserAsync(string roleUserId, string password)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.RoleUserId == roleUserId && u.PasswordHash == password);
        }

        public async Task<IEnumerable<User>> GetUsersByRoleAsync(string role)
        {
            return await _context.Users
                .Where(u => u.Role == role)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsersByAvailabilityAsync(bool isActive)
        {
            return await _context.Users
                .Where(u => u.IsActive == isActive)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsersByRoleAndAvailabilityAsync(string role, bool isActive)
        {
            return await _context.Users
                .Where(u => u.Role == role && u.IsActive == isActive)
                .ToListAsync();
        }

    }
}
