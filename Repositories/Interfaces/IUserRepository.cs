using Building_Construction_Management_System.Models;

namespace Building_Construction_Management_System.Repositories.Interfaces
{
    public interface IUserRepository
    {
        System.Threading.Tasks.Task AddUserAsync(User user);
        Task<User> GetUserByIdAsync(int userId);
        Task<IEnumerable<User>> GetUsersAsync();
        System.Threading.Tasks.Task UpdateUserAsync(User user);
    }
}
