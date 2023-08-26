using Microsoft.AspNetCore.Mvc;
using Task5.Models;
using Task5.Services.Users;

namespace Task5.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        public readonly IUserServices _UserService;
        private readonly ApplicationDbContext _context;

        public UsersController(IUserServices userService, ApplicationDbContext context)
        {
            _UserService = userService;
            _context = context;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Post(UserModel m)
        {
         //   if (m.Password != m.ConfirmPassword)
           //     return BadRequest("Password Not Matched");
            var token = _UserService.CreateToken(m.Username);
            //await _UserService.AddUser(m);
            var obj = new Tabels.User()
            {

                UserId = m.UserId,
                Username = m.Username,
                Email = m.Email,
                Password = m.Password,
                FullName = m.FullName,
                Bio = m.Bio,
                NumPosts = 0
            };
            await _context.Users.AddAsync(obj);
            await _context.SaveChangesAsync();

            return Ok(token);

        }
        [HttpPost("Reg")]
        public async Task<IActionResult> reg(UserModel m)
        {

            // Hash the password
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(m.Password);

            var obj = new Tabels.User()
            {
                UserId = m.UserId,
                Username = m.Username,
                Email = m.Email,
                Password = passwordHash,
                FullName = m.FullName,
                Bio = m.Bio,
                NumPosts = 0
            };

            await _context.Users.AddAsync(obj);
            await _context.SaveChangesAsync();

            // Generate token
            var token = _UserService.CreateToken(m.Username);

            // Return a response indicating successful registration
            return Ok(new { Message = "User registered successfully.", Token = token });
        }


        [HttpPost("Auth")]
        public async Task<IActionResult> Auth(AuthModel m)
        {
            var user = await _UserService.GetUser(m);
            if (user == null)
                return BadRequest("User Not Found");

            if (!BCrypt.Net.BCrypt.Verify(m.Password, user.Password))
            {
                return BadRequest("Wrong password.");
            }
            var token = _UserService.CreateToken(m.UserName);
            return Ok(token);

        }

    }
}
