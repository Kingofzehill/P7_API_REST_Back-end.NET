using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Services;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userRepository)
        {
            _userService = userRepository;
        }
        /// <summary>[HttpGet] User controller List method. 
        /// Call User service, then User repertory and 
        /// get User list.</summary>  
        /// <returns>Status code 200 (OK) with User list 
        /// OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized Administrator User access only</remarks>
        [HttpGet]
        [Route("list")]
        [Authorize(policy: "Admin")]
        public async Task<IActionResult> List()
        {            
            try
            {
                return Ok(await _userService.List());
            }
            catch (Exception ex)
            {                
                return StatusCode(500, "Une erreur interne s'est produite");
            }
        }

        /// <summary>[HttpGet] User controller Get method. 
        /// Call User service, then User repertory and get User
        /// corresponding to Id in input parameter.</summary>  
        /// <param name="id">Id of the User to get.</param>
        /// <returns>Status code 200 (OK) with User selected
        /// OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized Administrator User access only</remarks>
        [HttpGet]
        [Route("get/{id}")]
        [Authorize(policy: "Admin")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                var user = _userService.Get(id);
                if (user is not null)
                {
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }

        /// <summary>[HttpPost] User controller AddUser method. 
        /// Call User service, then User repertory and create User.</summary>  
        /// <param name="inputModel">POCO User input model class object.</param>
        /// <returns>Status code 200 (OK) with User created
        /// OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized Administrator User access only</remarks>
        [HttpPost]
        [Route("add")]
        [Authorize(policy: "Admin")]
        public async Task<IActionResult> AddUser([FromBody] UserInputModel inputModel)
        {            
            try
            {
                var user = await _userService.Create(inputModel);
                if (user is not null)
                {
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {                
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return BadRequest();
        }

        /// <summary>[HttpGet] User controller ShowUpdateForm method. 
        /// Call User service, then User repertory and get User.</summary>  
        /// <param name="id">Id of the User.</param>
        /// <returns>200 status code (OK) with selected User 
        /// OR 400 error status code  (BadResquest) or 500 error code if exception.</returns> 
        /// <remarks>Authenticated and authorized Administrator User access only</remarks>
        [HttpGet]
        [Route("update/{id}")]
        [Authorize(policy: "Admin")]
        public IActionResult ShowUpdateForm(int id)
        {
            try
            {
                var user = _userService.Get(id);
                if (user is not null)
                {
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }
        /// <summary>[HttpPost] User controller UpdateUser method. 
        /// Call User service, then User repertory and update User 
        /// corresponding to Id in input parameter</summary>   
        /// <param name="id">Id of the User to update.</param>
        /// <param name="inputModel">POCO User input model class object.</param>
        /// <returns>Status code 200 (OK) with updated User list 
        /// OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized Administrator User access only</remarks>
        [HttpPost]
        [Route("update/{id}")]
        [Authorize(policy: "Admin")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserInputModel inputModel)
        {
            try
            {
                var user = await _userService.Update(id, inputModel);
                if (user is not null)
                {
                    return Ok(await _userService.List());
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }
        /// <summary>[HttpDelete] User controller DeleteUser method. 
        /// Call User service, then User repertory and 
        /// delete User corresponding to Id in input parameter.</summary> 
        /// <param name="id">Id of the User to delete</param>
        /// <returns>Status code 200 (OK) with remaining User list 
        /// OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized Administrator User access only</remarks>
        [HttpDelete]
        [Route("{id}")]
        [Authorize(policy: "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _userService.Delete(id);
                if (user is not null)
                {
                    return Ok(await _userService.List());
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }
    }
}