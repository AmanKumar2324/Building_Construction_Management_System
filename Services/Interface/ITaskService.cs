using Building_Construction_Management_System.Models;

namespace Building_Construction_Management_System.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<Tasks>> GetTasksByProjectIdAsync(int projectId);
        Task<IEnumerable<Tasks>> GetDelayedTasksAsync();
        Task AddTaskAsync(Tasks task);
        Task<IEnumerable<Tasks>> GetTasksByPriorityAsync(string priority);
    }
}
