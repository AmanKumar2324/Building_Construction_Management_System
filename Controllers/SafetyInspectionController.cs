using Microsoft.AspNetCore.Mvc;
using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Services.Interfaces;
using Building_Construction_Management_System.Services.Interface;

namespace Building_Construction_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SafetyInspectionController : ControllerBase
    {
        private readonly ISafetyInspectionService _safetyInspectionService;

        public SafetyInspectionController(ISafetyInspectionService safetyInspectionService)
        {
            _safetyInspectionService = safetyInspectionService;
        }

        [HttpPost]
        public async Task<IActionResult> AddSafetyInspection(SafetyInspection inspection)
        {
            await _safetyInspectionService.AddSafetyInspectionAsync(inspection);
            return Created("", inspection);
        }

        [HttpGet("{projectId}")]
        public async Task<IActionResult> GetSafetyInspectionsByProjectAsync(int projectId)
        {
            // Validate the projectId (optional)
            if (projectId <= 0)
            {
                return BadRequest("Invalid project ID.");
            }

            try
            {
                // Get the safety inspections for the specified project
                var inspections = await _safetyInspectionService.GetSafetyInspectionsByProjectAsync(projectId);

                // If no inspections are found, return a NotFound response
                if (inspections == null || !inspections.Any())
                {
                    return NotFound($"No safety inspections found for project ID {projectId}.");
                }

                // Return the safety inspections as a 200 OK response
                return Ok(inspections);
            }
            catch (Exception ex)
            {
                // Return an internal server error if something goes wrong
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
