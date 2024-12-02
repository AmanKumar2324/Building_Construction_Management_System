using Building_Construction_Management_System.Models;

namespace Building_Construction_Management_System.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<Task>> GetTasksByProjectIdAsync(int projectId);
        Task<IEnumerable<Task>> GetDelayedTasksAsync();
        Task AddTaskAsync(Task task);
        Task<IEnumerable<Tasks>> GetTasksByPriorityAsync(string priority);
    }
}
