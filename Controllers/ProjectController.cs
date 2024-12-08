using Microsoft.AspNetCore.Mvc;
using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.DTOs;
using Building_Construction_Management_System.Services.Interfaces;

namespace Building_Construction_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var projects = await _projectService.GetProjectsAsync();
            return Ok(projects);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null) return NotFound();
            return Ok(project);
        }

        //[HttpPost]
        //public async Task<IActionResult> AddProject(Project project)
        //{
        //    await _projectService.AddProjectAsync(project);
        //    return CreatedAtAction(nameof(GetProjectById), new { id = project.ProjectId }, project);
        //}
        [HttpPost]
        public async Task<IActionResult> AddProject([FromBody] Project project)
        {
            try
            {
                await _projectService.AddProjectAsync(project);
                return CreatedAtAction(nameof(GetProjectById), new { id = project.ProjectId }, project);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while adding the project.", Details = ex.Message });
            }
        }


        //[HttpPut("{id:int}")]
        //public async Task<IActionResult> UpdateProject(int id, Project project)
        //{
        //    if (id != project.ProjectId) return BadRequest();
        //    await _projectService.UpdateProjectAsync(project);
        //    return NoContent();
        //}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] Project project)
        {
            if (id != project.ProjectId)
            {
                return BadRequest(new { Message = "Project ID in the URL does not match the body." });
            }

            try
            {
                await _projectService.UpdateProjectAsync(project);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while updating the project.", Details = ex.Message });
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            await _projectService.DeleteProjectAsync(id);
            return NoContent();
        }

        [HttpGet("budget-report")]
        public async Task<IActionResult> GetBudgetReport()
        {
            var report = await _projectService.GetBudgetReportAsync();
            return Ok(report);
        }

        [HttpGet("{id:int}/progress-report")]
        public async Task<IActionResult> GetProjectProgressReport(int id)
        {
            var report = await _projectService.GetProjectProgressReportAsync(id);
            return Ok(report);
        }

        [HttpGet("statuses")]
        public async Task<IActionResult> GetProjectStatuses()
        {
            try
            {
                var projectStatuses = await _projectService.GetProjectStatusesAsync();
                return Ok(projectStatuses); // Return 200 OK with the project statuses
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while fetching project statuses.", Details = ex.Message });
            }
        }
    }
}
