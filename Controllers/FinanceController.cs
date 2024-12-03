using Microsoft.AspNetCore.Mvc;
using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Services.Interfaces;
using Building_Construction_Management_System.Services.Interface;

namespace Building_Construction_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinanceController : ControllerBase
    {
        private readonly IFinanceService _financeService;

        public FinanceController(IFinanceService financeService)
        {
            _financeService = financeService;
        }

        [HttpGet("by-project/{projectId:int}")]
        public async Task<IActionResult> GetFinanceByProjectId(int projectId)
        {
            var finance = await _financeService.GetFinanceByProjectIdAsync(projectId);
            return Ok(finance);
        }

        [HttpPost]
        public async Task<IActionResult> AddFinance(Finance finance)
        {
            await _financeService.AddFinanceAsync(finance);
            return Created("", finance);
        }
    }
}
