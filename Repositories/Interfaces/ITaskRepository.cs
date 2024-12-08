using Building_Construction_Management_System.Models;

namespace Building_Construction_Management_System.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        System.Threading.Tasks.Task AddTaskAsync(Models.Task task);
        Task<IEnumerable<Models.Task>> GetTasksByProjectIdAsync(int projectId);
        Task<IEnumerable<Models.Task>> GetDelayedTasksAsync();
        Task<IEnumerable<Models.Task>> GetTasksByPriorityAsync(string priority);
        Task<IEnumerable<Models.Task>> GetTasksByRoleUserIdAsync(string roleUserId);
        System.Threading.Tasks.Task UpdateTaskStatusAsync(int taskId, string status);
    }
}
