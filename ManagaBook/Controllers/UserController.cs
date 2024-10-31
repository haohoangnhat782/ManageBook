
using Microsoft.AspNetCore.Mvc;
using ApplicationLayer.DTOs;
using ApplicationLayer.Service.Contract;

namespace ManagaBook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersAsync()
        {
            try
            {
                var users = await _userService.GetUsersAsync();
                if (users == null || !users.Any())
                    return NotFound("Users not found.");
                return Ok(users);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult> CreateUserAsync([FromBody] UserDto user)
        {
            try
            {
                await _userService.CreateUserAsync(user);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut]
        [Produces("application/json")]
        public async Task<ActionResult> UpdateUserAsync([FromBody] UserDto user)
        {
            try
            {
                await _userService.UpdateUserAsync(user);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult> DeleteUserAsync(int id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult> GetUserAsync(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }
    }


}