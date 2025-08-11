using LibraryAPI.Models.Auth;
using LibraryAPI.Models.DTOs.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryAPI.Controllers
{
    /// <summary>
    /// Controller responsible for authentication operations such as login and token generation.
    /// <para>
    /// NOTE: This controller currently contains a mock implementation for demonstration purposes only.
    /// In a real-world scenario, authentication and JWT token generation should be handled by a dedicated authentication service.
    /// </para>
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="jwtSettings">JWT configuration settings.</param>
        public AuthController(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        /// <summary>
        /// Mock login endpoint that validates hardcoded credentials and returns a JWT token.
        /// <para>
        /// This is only for testing and should be replaced with proper authentication logic calling an auth service.
        /// </para>
        /// </summary>
        /// <param name="loginDto">The login request containing username and password.</param>
        /// <returns>
        /// A JWT token and its expiration date if authentication succeeds; 
        /// otherwise, returns Unauthorized.
        /// </returns>
        [HttpPost("login")]
        public IActionResult Login(LoginRequestDto loginDto)
        {
            // Mock check - replace with real authentication call in production
            if (loginDto.Username != "admin" || loginDto.Password != "password")
            {
                return Unauthorized("Invalid username or password.");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, loginDto.Username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            var response = new LoginResponseDto
            {
                Token = jwtToken,
                Expiration = tokenDescriptor.Expires ?? DateTime.UtcNow.AddMinutes(60)
            };

            return Ok(response);
        }
    }
}
