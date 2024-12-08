using Building_Construction_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Building_Construction_Management_System.Repositories.Interfaces
{
    public interface IUserRepository
    {
        System.Threading.Tasks.Task AddUserAsync(User user);
        Task<User> GetUserByIdAsync(int userId);
        Task<IEnumerable<User>> GetUsersAsync();
        System.Threading.Tasks.Task UpdateUserAsync(User user);
        System.Threading.Tasks.Task DeleteUserAsync(int userId);
        Task<User> GetUserByRoleUserIdAsync(string roleUserId);
        Task<User> AuthenticateUserAsync(string roleUserId, string password);
        Task<IEnumerable<User>> GetUsersByRoleAsync(string role);
        Task<IEnumerable<User>> GetUsersByAvailabilityAsync(bool isActive);
        Task<IEnumerable<User>> GetUsersByRoleAndAvailabilityAsync(string role, bool isActive);


    }
}
