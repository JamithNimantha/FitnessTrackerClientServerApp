using FitnessTrackerServerApp.DTO;
using FitnessTrackerServerApp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackerServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController: ControllerBase
    {

        private readonly IUserService _service;

        public AuthController(IUserService service)
        {
            _service = service;
        }

        // POST: api/RegisterUser
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/RegisterUser")]
        public async Task<ActionResult<UserDTO>> RegisterUser(RegisterUserDTO user)
        {
            var exists = await _service.UserExists(user.UserName);
            if (exists)
            {
                return Conflict();
            }

            if (user.Password != user.ConfirmPassword)
            {
                return BadRequest("Passwords do not match!");
            }
            try
            {
                return await _service.RegisterUser(user);
            }
            catch (DbUpdateException)
            {
                throw;
            }

        }

        // POST: api/Auth
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/Auth")]
        public async Task<ActionResult<string>> Authenticate(LoginUserDTO user)
        {

            var token =  await _service.Authenticate(user);

            if (token == null)
            {
                return BadRequest("Invalid UserName or Password!");
            }

            return token;
        }

        // POST: api/Auth
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/ChangePassword")]
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
