using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using FitnessTrackerServerApp.Service;
using FitnessTrackerServerApp.DTO;

namespace FitnessTrackerServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        // GET: api/Users
        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUser()
        {
          return await _service.GetUsers();
        }

        // GET: api/Users/5
        [HttpGet("{userName}"), Authorize]
        public async Task<ActionResult<UserDTO>> GetUser(string userName)
        {
            return await _service.GetUser(userName);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{UserName}"), Authorize]
        public async Task<IActionResult> UpdateUser(string UserName, UserDTO user)
        {
            //ModelState.Remove("UserDTO.Password");
            if (UserName != user.UserName)
            {
                return BadRequest();
            }

            var exists = await _service.UserExists(UserName);
            if (!exists)
            {
                return NotFound();
            }

            try
            {
                await _service.UpdateUser(UserName, user);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

           
            return Ok();
        }

        // DELETE: api/Users/5
        [HttpDelete("{UserName}"), Authorize]
        public async Task<IActionResult> DeleteUser(string UserName)
        {
            var exists = await _service.UserExists(UserName);
            if (!exists)
            {
                return NotFound();
            }

            return await _service.DeleteUser(UserName);

        }

        [HttpPut("ChangePassword"), Authorize]
        public async Task<ActionResult<UserDTO>> UpdateUserPassowrd(UpdatePasswordDTO dto)
        {
            var exists = await _service.UserExists(dto.UserName);
            if (!exists)
            {
                return NotFound();
            }

            if (dto.Password != dto.ConfirmPassword)
            {
                return BadRequest("Passwords do not match!");
            }

            return await _service.UpdateUserPassword(dto.UserName, dto.Password);
        }

    }
}
