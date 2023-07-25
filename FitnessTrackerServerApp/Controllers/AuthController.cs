using FitnessTrackerServerApp.DTO;
using FitnessTrackerServerApp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackerServerApp.Controllers
{
    [Route("[controller]")]
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
        [HttpPost("RegisterUser", Name = "Register a New User")]
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
        [HttpPost("Login", Name = "Authenticate User")]
        public async Task<ActionResult<string>> Authenticate(LoginUserDTO user)
        {

            var token =  await _service.Authenticate(user);

            if (token == null)
            {
                return BadRequest("Invalid UserName or Password!");
            }

            return token;
        }

       
        
    }
}
