﻿using Building_Construction_Management_System.Models;

namespace Building_Construction_Management_System.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        System.Threading.Tasks.Task AddUserAsync(User user);
        System.Threading.Tasks.Task UpdateUserAsync(User user);
        System.Threading.Tasks.Task DeleteUserAsync(int userId);
        Task<IEnumerable<User>> GetUsersByRoleAsync(string role);
        Task<IEnumerable<User>> GetUsersByAvailabilityAsync(bool isActive);
        Task<IEnumerable<User>> GetUsersByRoleAndAvailabilityAsync(string role, bool isActive);
    }
}
