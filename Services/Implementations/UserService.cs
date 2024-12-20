﻿using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Repositories.Interfaces;
using Building_Construction_Management_System.Services.Interfaces;

namespace Building_Construction_Management_System.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async System.Threading.Tasks.Task AddUserAsync(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.PasswordHash))
            {
                throw new ArgumentException("Username and password are required.");
            }

            await _userRepository.AddUserAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task UpdateUserAsync(User user)
        {
            if (user.UserId <= 0)
            {
                throw new ArgumentException("Invalid user ID.");
            }

            await _userRepository.UpdateUserAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }
        public async System.Threading.Tasks.Task DeleteUserAsync(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentException("Invalid user ID.");
            }

            await _userRepository.DeleteUserAsync(userId);  // Call to repository to delete user
            await _unitOfWork.SaveChangesAsync();  // Save changes after deletion
        }
        public async Task<IEnumerable<User>> GetUsersByRoleAsync(string role)
        {
            return await _userRepository.GetUsersByRoleAsync(role);
        }

        public async Task<IEnumerable<User>> GetUsersByAvailabilityAsync(bool isActive)
        {
            return await _userRepository.GetUsersByAvailabilityAsync(isActive);
        }

        public async Task<IEnumerable<User>> GetUsersByRoleAndAvailabilityAsync(string role, bool isActive)
        {
            return await _userRepository.GetUsersByRoleAndAvailabilityAsync(role, isActive);
        }
    }
}
