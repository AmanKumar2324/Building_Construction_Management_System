using Microsoft.AspNetCore.Mvc;
using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Services.Interfaces;

namespace Building_Construction_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("by-project/{projectId:int}")]
        public async Task<IActionResult> GetTasksByProjectId(int projectId)
        {
            var tasks = await _taskService.GetTasksByProjectIdAsync(projectId);
            return Ok(tasks);
        }

        [HttpGet("delayed")]
        public async Task<IActionResult> GetDelayedTasks()
        {
            var tasks = await _taskService.GetDelayedTasksAsync();
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(Tasks task)
        {
            await _taskService.AddTaskAsync(task);
            return Created("", task);
        }

        // GET: api/tasks/bypriority/{priority}
        [HttpGet("bypriority/{priority}")]
        public async Task<ActionResult<IEnumerable<Tasks>>> GetTasksByPriorityAsync(string priority)
        {
            if (string.IsNullOrWhiteSpace(priority))
            {
                return BadRequest("Priority is required.");
            }

            try
            {
                var tasks = await _taskService.GetTasksByPriorityAsync(priority);
                if (tasks == null || tasks.Any() == false)
                {
                    return NotFound("No tasks found for the given priority.");
                }

                return Ok(tasks); // Return 200 OK with tasks
            }
            catch (Exception ex)
            {
                // Log exception (optional) and return a 500 error with a message
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
