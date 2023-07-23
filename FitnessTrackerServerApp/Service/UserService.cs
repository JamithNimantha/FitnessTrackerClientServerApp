using FitnessTrackerApp.Model;
using FitnessTrackerServerApp.Data;
using FitnessTrackerServerApp.DTO;
using FitnessTrackerServerApp.Utility;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackerServerApp.Service
{
    public class UserService : IUserService
    {
        private readonly FitnessTrackerServerAppDBContext _db;
        private readonly IConfiguration iconfiguration;

        public UserService(FitnessTrackerServerAppDBContext fitnessTrackerServerAppDBContext, IConfiguration iconfiguration)
        {
            _db = fitnessTrackerServerAppDBContext;
            this.iconfiguration = iconfiguration;
        }

        public async Task<string> Authenticate(LoginUserDTO loginUserDTO)
        {
            var user = await GetUser(loginUserDTO.UserName);

           if (user.Value == null || !VerifyPassword(loginUserDTO.Password, user.Value.Password))
            {
                return null;
            }
  
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.Value.UserName),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<UserDTO> RegisterUser(RegisterUserDTO registerUserDTO)
        {
            var newUser = new User();
            newUser.UserName = registerUserDTO.UserName;
            newUser.Name = registerUserDTO.UserName;
            newUser.Password = GetSaltedHash(registerUserDTO.Password);
            newUser.Gender = registerUserDTO.Gender;
            newUser.DateofBirth = registerUserDTO.DateofBirth;
            newUser.Height = registerUserDTO.Height;

            try
            {
                _db.User.Add(newUser);
                await _db.SaveChangesAsync();
                WeightEntry weightEntry = new WeightEntry();
                weightEntry.UserName = newUser.UserName;
                weightEntry.Weight = registerUserDTO.Weight;
                weightEntry.Date = DateTime.Now;
                _db.WeightEntry.Add(weightEntry);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {

                throw;
            }
            return ConvertToDTO(newUser);
        }

        private async Task<ActionResult<User>> FindUser(string UserName)
        {
            if (UserName == null)
            {
                return new BadRequestResult();
            }

            User? user = await _db.User.FindAsync(UserName);

            if (user == null)
            {
                return new NotFoundResult();
            }

            return user;
        }

        public async Task<ActionResult<UserDTO>> GetUser(string UserName)
        {
            var user = await FindUser(UserName);

            if (user.Result is NotFoundResult)
            {
                return new NotFoundResult();
            }

            return ConvertToDTO(user.Value);
        }

        private static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            string hashedEnteredPassword = GetSaltedHash(enteredPassword);
            return storedHash.Equals(hashedEnteredPassword);
        }

        private static string GetSaltedHash(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] saltedPasswordBytes = Encoding.UTF8.GetBytes(password + Util.SALT_STRING);
                byte[] hashBytes = sha256.ComputeHash(saltedPasswordBytes);
                string hashedPassword = Convert.ToBase64String(hashBytes);
                return hashedPassword;
            }
        }

      
        public async Task<ActionResult<UserDTO>> UpdateUser(string UserName, UserDTO user)
        {
            var userToUpdate =  await _db.User.FindAsync(UserName);

            userToUpdate.Name = user.Name;
            userToUpdate.DateofBirth = user.DateofBirth;
            userToUpdate.Height = user.Height;
            userToUpdate.Gender = user.Gender;
            

            _db.Entry(userToUpdate).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return ConvertToDTO(userToUpdate);

        }

        public async Task<ActionResult<UserDTO>> UpdateUserPassword(string UserName, string password)
        {
            var userToUpdate = await _db.User.FindAsync(UserName);

            userToUpdate.Password = GetSaltedHash(password);

            _db.Entry(userToUpdate).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return ConvertToDTO(userToUpdate);

        }

        public async Task<ActionResult> DeleteUser(string UserName)
        {
            var user = await _db.User.FindAsync(UserName);
            _db.User.Remove(user);
            await _db.SaveChangesAsync();
            return new NoContentResult();
        }

        public async Task<bool> UserExists(string UserName)
        {
            var user = await _db.User.FirstOrDefaultAsync(e => e.UserName == UserName);
            return user != null;
        }

        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _db.User.ToListAsync();

            var usersDTO = new List<UserDTO>();
            foreach (var user in users)
            {
                usersDTO.Add(ConvertToDTO(user));
            }
            return usersDTO;
        }

        private static UserDTO ConvertToDTO(User model)
        {
            return new UserDTO
            {
               UserName = model.UserName,
               Password = model.Password,
               Name = model.Name,
               DateofBirth = model.DateofBirth,
               Height = model.Height,
               Gender = model.Gender
            };
        }

        private static User ConvertToModel(UserDTO dto)
        {
            return new User
            {
                UserName = dto.UserName,
                Password = dto.Password,
                Name = dto.Name,
                DateofBirth = dto.DateofBirth,
                Height = dto.Height,
                Gender = dto.Gender
            };
        }

    }
}