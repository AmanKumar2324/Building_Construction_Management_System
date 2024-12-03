using Microsoft.AspNetCore.Mvc;
using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Services.Interfaces;

namespace Building_Construction_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        //[HttpGet("by-project/{projectId:int}")]
        //public async Task<IActionResult> GetMaterialsByProjectId(int projectId)
        //{
        //    var materials = await _materialService.GetMaterialsByProjectIdAsync(projectId);
        //    return Ok(materials);
        //}

        [HttpPost]
        public async Task<IActionResult> AddMaterial(Material material)
        {
            await _materialService.AddMaterialAsync(material);
            return Created("", material);
        }

        [HttpPatch("{materialId:int}/status")]
        public async Task<IActionResult> UpdateMaterialStatus(int materialId, [FromBody] string status)
        {
            await _materialService.UpdateMaterialStatusAsync(materialId, status);
            return NoContent();
        }
    }
}
