namespace Building_Construction_Management_System.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task AddTaskAsync(Task task);
        Task<IEnumerable<Task>> GetTasksByProjectIdAsync(int projectId);
        Task<IEnumerable<Task>> GetDelayedTasksAsync();
        Task<IEnumerable<Task>> GetTasksByPriorityAsync(string priority);

    }
}
