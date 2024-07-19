using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using P7CreateRestApi.Models.InputModels;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("Authentication")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;
        public AuthController(UserManager<User> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }
        /// <summary>user login which generates a token if successfull.</summary> 
        /// <param name="inputModel">User input model object.</param>
        /// <returns>Generated token.</returns> 
        /// <remarks>Auth controller Login method. 
        /// URI: /Auth/login.</remarks>
        /// <response code ="200">OK.</response>
        /// <response code ="400">BadRequest.</response>
        /// <response code ="401">Unauthorized.</response>
        /// <response code ="500">Internal error (exception).</response>
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginInputModel inputModel)
        {
            Log.Information("{UserName} user authentification.", inputModel.UserName);
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
                Log.Error(ex, "Internal error (500) occurs on {UserName} user authentification", inputModel.UserName);
                return StatusCode(500, "Internal error occurs.");
            }
            Log.Warning("Unauthorized (401) result for {UserName} user authentification", inputModel.UserName);
            return Unauthorized();
        }
    }
}