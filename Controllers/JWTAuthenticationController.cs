using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWTAuthenticationChallenge.Models;

namespace JWTAuthenticationController.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private static List<User> users = new List<User>();
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthController(IPasswordHasher<User> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            user.Password = _passwordHasher.HashPassword(user, user.Password);
            users.Add(user);
            return Ok(new { message = "Usu�rio registrado com sucesso" });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login loginUser)
        {
            var user = users.FirstOrDefault(u => u.Username == loginUser.Username);

            if (user == null)
                return Unauthorized(new { message = "Usu�rio n�o encontrado" });

            var passwordVerification = _passwordHasher.VerifyHashedPassword(user, user.Password, loginUser.Password);

            if (passwordVerification != PasswordVerificationResult.Success)
                return Unauthorized(new { message = "Senha incorreta" });

            // Gera o token JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("8NgvNBEalwf9Sn52YeVwPmFSKwaDTOIq");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user.Username) }),
                Expires = DateTime.UtcNow.AddHours(1),
                Audience = "https://localhost:7105",
                Issuer = "https://localhost:7105",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
        }

        [Authorize]
        [HttpGet("protected")]
        public IActionResult Protected()
        {
            return Ok(new { message = "Voc� acessou um endpoint protegido!" });
        }
    }
}