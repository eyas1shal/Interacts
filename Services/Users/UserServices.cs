using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Task5.Models;
using Task5.Tabels;

namespace Task5.Services.Users
{
    public class UserServices : IUserServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserServices(ApplicationDbContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<User> AddUser(UserModel m)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(m.Password);

            var user = new User()
            {
                FullName = m.FullName,
                Email = m.Email,
                Password = passwordHash
            };
            var result = await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public string CreateToken(string userName)
        {
            List<Claim> claims = new List<Claim> {
                new Claim("name", userName),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "User"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: creds
            );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public string GetCurrentLoggedIn()
        {
            string result = string.Empty;
            if (_httpContextAccessor.HttpContext is not null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue("name");
            }
            return result;
        }

        public async Task<User?> GetUser(AuthModel m)
        {
            return await _context.Users.FirstOrDefaultAsync(c => c.Email.ToUpper() == m.UserName.ToUpper());
        }
    }
}
