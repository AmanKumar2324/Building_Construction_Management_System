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

        public async System.Threading.Tasks.Task AddTaskAsync(Models.Task task)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC AddTask @ProjectId={task.ProjectId}, @TaskName={task.TaskName}, @AssignedTo={task.AssignedTo}, @StartDate={task.StartDate}, @EndDate={task.EndDate}, @Priority={task.Priority}, @Status={task.Status}");
        }

        public async Task<IEnumerable<Models.Task>> GetTasksByProjectIdAsync(int projectId)
        {
            return await _context.Tasks.FromSqlInterpolated($"EXEC GetTasksByProject @ProjectId={projectId}").ToListAsync();
        }

        public async Task<IEnumerable<Models.Task>> GetDelayedTasksAsync()
        {
            return await _context.Tasks.FromSqlInterpolated($"EXEC GetDelayedTasks").ToListAsync();
        }
        public async Task<IEnumerable<Models.Task>> GetTasksByPriorityAsync(string priority)
        {
            return await _context.Tasks
                .FromSqlInterpolated($"EXEC GetTasksByPriority @Priority={priority}")
                .ToListAsync();
        }
        public async Task<IEnumerable<Models.Task>> GetTasksByRoleUserIdAsync(string roleUserId)
        {
            return await _context.Tasks
                .Where(t => t.AssignedTo == roleUserId)
                .Select(t => new Models.Task
                {
                    TaskId = t.TaskId,
                    TaskName = t.TaskName,
                    StartDate = t.StartDate,
                    EndDate = t.EndDate,
                    Priority = t.Priority,
                    Status = t.Status
                })
                .ToListAsync();
        }
        public async System.Threading.Tasks.Task UpdateTaskStatusAsync(int taskId, string status)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.TaskId == taskId);
            if (task == null)
            {
                throw new ArgumentException("Task not found.");
            }

            task.Status = status;
            await _context.SaveChangesAsync();
        }


    }
}
