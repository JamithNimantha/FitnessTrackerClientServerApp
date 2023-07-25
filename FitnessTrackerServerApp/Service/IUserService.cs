using FitnessTrackerServerApp.Model;
using FitnessTrackerServerApp.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackerServerApp.Service
{
    public interface IUserService
    {
        Task<UserDTO> RegisterUser(RegisterUserDTO registerUserDTO);
        Task<string> Authenticate(LoginUserDTO loginUserDTO);
        Task<ActionResult<IEnumerable<UserDTO>>> GetUsers();
        Task<ActionResult<UserDTO>> GetUser(string UserName);
        Task<ActionResult<UserDTO>> UpdateUser(string UserName, UserDTO user);
        Task<ActionResult<UserDTO>> UpdateUserPassword(string UserName, string password);
        Task<ActionResult> DeleteUser(string UserName);
        Task<bool> UserExists(string UserName);



    }
}
