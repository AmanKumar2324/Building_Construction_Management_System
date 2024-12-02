using Building_Construction_Management_System.Models;

namespace Building_Construction_Management_System.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task AddTaskAsync(Tasks task);
        Task<IEnumerable<Tasks>> GetTasksByProjectIdAsync(int projectId);
        Task<IEnumerable<Tasks>> GetDelayedTasksAsync();
        Task<IEnumerable<Tasks>> GetTasksByPriorityAsync(string priority);
    }
}
