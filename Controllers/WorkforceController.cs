using Microsoft.AspNetCore.Mvc;
using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Services.Interfaces;
using Building_Construction_Management_System.Services.Interface;

namespace Building_Construction_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkforceController : ControllerBase
    {
        private readonly IWorkforceService _workforceService;

        public WorkforceController(IWorkforceService workforceService)
        {
            _workforceService = workforceService;
        }

        [HttpGet("by-project/{projectId:int}")]
        public async Task<IActionResult> GetWorkforceByProjectId(int projectId)
        {
            var workforce = await _workforceService.GetWorkforceByProjectIdAsync(projectId);
            return Ok(workforce);
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkforce(Workforce workforce)
        {
            await _workforceService.AddWorkforceAsync(workforce);
            return Created("", workforce);
        }
        [HttpPut("{workerId}")]
        public async Task<IActionResult> UpdateWorkforceAsync(int workerId, [FromBody] Workforce workforce)
        {
            if (workerId <= 0 || workforce == null)
            {
                return BadRequest("Invalid input.");
            }

            // Validate that required fields are provided in the request body
            if (string.IsNullOrWhiteSpace(workforce.Role))
            {
                return BadRequest("Role is required.");
            }

            if (string.IsNullOrWhiteSpace(workforce.AttendanceStatus))
            {
                return BadRequest("Attendance Status is required.");
            }

            // Validate performanceRating and ensure it is not null or default (if nullable)
            if (!workforce.PerformanceRating.HasValue || workforce.PerformanceRating.Value <= 0)
            {
                return BadRequest("Performance Rating must be a positive value.");
            }

            try
            {
                // Call the service method to update workforce
                await _workforceService.UpdateWorkforceAsync(workerId, workforce.Role, workforce.AttendanceStatus, workforce.PerformanceRating.Value);
                return NoContent(); // Return 204 No Content if the update is successful
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Return 400 Bad Request for validation errors
            }
            catch (InvalidOperationException ex)
            {
                // Log the exception (optional) and return a 500 error if something goes wrong
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


    }
}
