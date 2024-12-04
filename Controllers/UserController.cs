using Microsoft.AspNetCore.Mvc;
using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Services.Interfaces;

namespace Building_Construction_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.UserId) return BadRequest();
            await _userService.UpdateUserAsync(user);
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUserAsync(id); // Call to the service to delete the user
                return NoContent(); // Return status 204 (No Content) on successful deletion
            }
            catch (ArgumentException ex)
            {
                // Handle invalid or missing user ID
                return BadRequest(ex.Message); // Return a bad request if the user ID is invalid
            }
        }
    }
}
