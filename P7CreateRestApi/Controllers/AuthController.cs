using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using P7CreateRestApi.Models.InputModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;
        public AuthController(UserManager<User> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }
        /// <summary>Auth controller Login method. 
        /// Allows user to authenticate. 
        /// Check password validity, if ok generates token.</summary>  
        /// <param name="inputModel">POCO Login input model class object.</param>
        /// <returns>Status code 200 (OK) with the generated token OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized Administrator User access only</remarks>
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginInputModel inputModel)
        {            
            try
            {
                var user = await _userManager.FindByNameAsync(inputModel.UserName);
                var result = await _userManager.CheckPasswordAsync(user, inputModel.Password);
                if (result)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_config["Jwt:SecretKey"]);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                        new (ClaimTypes.Name, user.UserName),
                        new (ClaimTypes.Role, user.Role)
                        }),
                        Expires = DateTime.UtcNow.AddHours(1),
                        Audience = _config["Jwt:Audience"],
                        Issuer = _config["Jwt:Issuer"],
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);

                    return Ok(new { Token = tokenString });
                }
            }
            catch (Exception ex)
            {                
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return Unauthorized();
        }
    }
}