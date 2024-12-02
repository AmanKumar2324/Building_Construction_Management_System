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

        public async Task<IEnumerable<Tasks>> GetTasksByProjectIdAsync(int projectId)
        {
            return await _taskRepository.GetTasksByProjectIdAsync(projectId);
        }

        public async Task<IEnumerable<Tasks>> GetDelayedTasksAsync()
        {
            return await _taskRepository.GetDelayedTasksAsync();
        }

        public async Task AddTaskAsync(Tasks task)
        {
            if (string.IsNullOrWhiteSpace(task.TaskName))
            {
                throw new ArgumentException("Task name is required.");
            }

            await _taskRepository.AddTaskAsync(task);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<IEnumerable<Tasks>> GetTasksByPriorityAsync(string priority)
        {
            if (string.IsNullOrWhiteSpace(priority))
            {
                throw new ArgumentException("Priority is required.");
            }

            return await _taskRepository.GetTasksByPriorityAsync(priority);
        }
    }
}
