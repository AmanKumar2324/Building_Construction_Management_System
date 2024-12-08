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
        public async Task<IActionResult> AddTask(Models.Task task)
        {
            await _taskService.AddTaskAsync(task);
            return Created("", task);
        }

        // GET: api/tasks/bypriority/{priority}
        [HttpGet("bypriority/{priority}")]
        public async Task<ActionResult<IEnumerable<Models.Task>>> GetTasksByPriorityAsync(string priority)
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
        [HttpGet("assigned-to/{roleUserId}")]
        public async Task<IActionResult> GetTasksByRoleUserId(string roleUserId)
        {
            try
            {
                var tasks = await _taskService.GetTasksByRoleUserIdAsync(roleUserId);

                if (!tasks.Any())
                {
                    return NotFound(new { Message = "No tasks found for the given RoleUserId." });
                }

                return Ok(tasks);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while fetching tasks.", Details = ex.Message });
            }
        }
        // PUT api/Task/{taskId}/status
        [HttpPatch("{taskId:int}/status")]
        public async Task<IActionResult> UpdateTaskStatus(int taskId, [FromBody] string status)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(status))
                {
                    return BadRequest(new { Message = "Status cannot be empty." });
                }

                // Update task status
                await _taskService.UpdateTaskStatusAsync(taskId, status);

                return NoContent(); // Successfully updated
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while updating the task.", Details = ex.Message });
            }
        }
    }
}
