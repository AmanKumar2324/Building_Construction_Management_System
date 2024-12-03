using Microsoft.AspNetCore.Mvc;
using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Services.Interfaces;
using Building_Construction_Management_System.Services.Interface;

namespace Building_Construction_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("by-project/{projectId:int}")]
        public async Task<IActionResult> GetReportsByProjectId(int projectId)
        {
            var reports = await _reportService.GetReportsByProjectIdAsync(projectId);
            return Ok(reports);
        }

        [HttpPost]
        public async Task<IActionResult> AddReport(Report report)
        {
            await _reportService.AddReportAsync(report);
            return Created("", report);
        }
    }
}
