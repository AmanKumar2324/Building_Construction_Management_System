using Microsoft.AspNetCore.Mvc;
using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Services.Interfaces;
using Building_Construction_Management_System.Services.Interface;

namespace Building_Construction_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet("by-project/{projectId:int}")]
        public async Task<IActionResult> GetEquipmentByProjectId(int projectId)
        {
            var equipment = await _equipmentService.GetEquipmentByProjectIdAsync(projectId);
            return Ok(equipment);
        }

        [HttpPost]
        public async Task<IActionResult> AddEquipment(Equipment equipment)
        {
            await _equipmentService.AddEquipmentAsync(equipment);
            return Created("", equipment);
        }

        [HttpPatch("{equipmentId:int}/condition")]
        public async Task<IActionResult> UpdateEquipmentCondition(int equipmentId, [FromBody] string condition)
        {
            await _equipmentService.UpdateEquipmentConditionAsync(equipmentId, condition);
            return NoContent();
        }
    }
}
