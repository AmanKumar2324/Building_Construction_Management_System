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

        // GET /api/users/filter?role=Admin&isActive=true - Filter users by role and availability
        [HttpGet("filter")]
        public async Task<IActionResult> GetFilteredUsers([FromQuery] string role, [FromQuery] bool? isActive)
        {
            try
            {
                IEnumerable<User> users;

                if (!string.IsNullOrEmpty(role) && isActive.HasValue)
                {
                    // Filter by both role and availability
                    users = await _userService.GetUsersByRoleAndAvailabilityAsync(role, isActive.Value);
                }
                else if (!string.IsNullOrEmpty(role))
                {
                    // Filter by role
                    users = await _userService.GetUsersByRoleAsync(role);
                }
                else if (isActive.HasValue)
                {
                    // Filter by availability
                    users = await _userService.GetUsersByAvailabilityAsync(isActive.Value);
                }
                else
                {
                    // If no filters are applied, return all users
                    users = await _userService.GetUsersByRoleAsync("Admin"); // Optional default behavior
                }

                if (users == null || !users.Any())
                {
                    return NotFound(new { Message = "No users found matching the criteria." });
                }

                return Ok(users); // Return filtered users
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while fetching users.", Details = ex.Message });
            }
        }
    }
}
