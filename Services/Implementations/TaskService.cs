using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Repositories.Interfaces;
using Building_Construction_Management_System.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Building_Construction_Management_System.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TaskService(ITaskRepository taskRepository, IUnitOfWork unitOfWork)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Models.Task>> GetTasksByProjectIdAsync(int projectId)
        {
            return await _taskRepository.GetTasksByProjectIdAsync(projectId);
        }

        public async Task<IEnumerable<Models.Task>> GetDelayedTasksAsync()
        {
            return await _taskRepository.GetDelayedTasksAsync();
        }

        public async System.Threading.Tasks.Task AddTaskAsync(Models.Task task)
        {
            if (string.IsNullOrWhiteSpace(task.TaskName))
            {
                throw new ArgumentException("Task name is required.");
            }

            await _taskRepository.AddTaskAsync(task);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<IEnumerable<Models.Task>> GetTasksByPriorityAsync(string priority)
        {
            if (string.IsNullOrWhiteSpace(priority))
            {
                throw new ArgumentException("Priority is required.");
            }

            return await _taskRepository.GetTasksByPriorityAsync(priority);
        }
        public async Task<IEnumerable<Models.Task>> GetTasksByRoleUserIdAsync(string roleUserId)
        {
            if (string.IsNullOrWhiteSpace(roleUserId))
            {
                throw new ArgumentException("RoleUserId cannot be null or empty.");
            }

            return await _taskRepository.GetTasksByRoleUserIdAsync(roleUserId);
        }

        public async System.Threading.Tasks.Task UpdateTaskStatusAsync(int taskId, string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                throw new ArgumentException("Status cannot be null or empty.");
            }

            // Optionally, you can add more validation logic based on business requirements.

            await _taskRepository.UpdateTaskStatusAsync(taskId, status);
        }


    }
}
