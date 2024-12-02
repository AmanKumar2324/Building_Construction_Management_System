using Building_Construction_Management_System.Data;
using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Building_Construction_Management_System.Repositories.Implementations
{
    public class TaskRepository : ITaskRepository
    {
        private readonly BuildingConstructionDbContext _context;

        public TaskRepository(BuildingConstructionDbContext context)
        {
            _context = context;
        }

        public async Task AddTaskAsync(Tasks task)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC AddTask @ProjectId={task.ProjectId}, @TaskName={task.TaskName}, @AssignedTo={task.AssignedTo}, @StartDate={task.StartDate}, @EndDate={task.EndDate}, @Priority={task.Priority}, @Status={task.Status}");
        }

        public async Task<IEnumerable<Tasks>> GetTasksByProjectIdAsync(int projectId)
        {
            return await _context.Tasks.FromSqlInterpolated($"EXEC GetTasksByProject @ProjectId={projectId}").ToListAsync();
        }

        public async Task<IEnumerable<Tasks>> GetDelayedTasksAsync()
        {
            return await _context.Tasks.FromSqlInterpolated($"EXEC GetDelayedTasks").ToListAsync();
        }
        public async Task<IEnumerable<Tasks>> GetTasksByPriorityAsync(string priority)
        {
            return await _context.Tasks
                .FromSqlInterpolated($"EXEC GetTasksByPriority @Priority={priority}")
                .ToListAsync();
        }
    }
}
