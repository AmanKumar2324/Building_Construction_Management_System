using Microsoft.AspNetCore.Mvc;
using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Services.Interfaces;
using Building_Construction_Management_System.Services.Interface;

namespace Building_Construction_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendorController : ControllerBase
    {
        private readonly IVendorService _vendorService;

        public VendorController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetVendors()
        {
            var vendors = await _vendorService.GetVendorsAsync();
            return Ok(vendors);
        }

        [HttpPost]
        public async Task<IActionResult> AddVendor(Vendor vendor)
        {
            await _vendorService.AddVendorAsync(vendor);
            return Created("", vendor);
        }

        [HttpDelete("{vendorId:int}")]
        public async Task<IActionResult> RemoveVendor(int vendorId)
        {
            await _vendorService.RemoveVendorAsync(vendorId);
            return NoContent();
        }

        [HttpPatch("{vendorId:int}/status")]
        public async Task<IActionResult> UpdateVendorStatus(int vendorId, [FromBody] string status)
        {
            await _vendorService.UpdateVendorStatusAsync(vendorId, status);
            return NoContent();
        }
    }
}
