using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Services;
using Serilog;

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
        /// Get User items list. </summary>  
        /// <returns>User list.</returns> 
        /// <remarks>Authenticated and authorized User access only.</remarks>
        /// <remarks>Route: /User/list.</remarks>
        /// <response code ="200">OK.</response>        
        /// <response code ="500">Internal error (exception).</response>
        [HttpGet]
        [Route("list")]
        [Authorize(policy: "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> List()
        {            
            try
            {
                Log.Information("'User' list request.");
                return Ok(await _userService.List());
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error (500) occurs on 'User' list request.");
                return StatusCode(500, "Internal error occurs.");
            }
        }

        /// <summary>[HttpGet] User controller Get method. 
        /// Get User item for the User Id in parameter. </summary>  
        /// <param name="id">User Id.</param>
        /// <returns>Selected User.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        /// <remarks>Route: /User/get/{id}.</remarks>
        /// <response code ="200">OK.</response>  
        /// <response code ="404">Not found.</response>
        /// <response code ="500">Internal error (exception).</response>
        [HttpGet]
        [Route("get/{id}")]
        [Authorize(policy: "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get([FromRoute] int id)
        {
            Log.Information("Get request of 'User' for id: {id}.", id);
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
                Log.Error(ex, "Internal error occurs on try to get 'User' for id: {id}.", id);
                return StatusCode(500, "Internal error occurs.");
            }
            Log.Warning("'User' item not found for id: {id}.", id);
            return NotFound();
        }

        /// <summary>[HttpPost] User controller AddUser method. 
        /// Add a User item. </summary>  
        /// <param name="inputModel">User to add.</param>
        /// <returns>User item created.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        /// <remarks>Route: /User/add.</remarks>
        /// <response code ="200">OK.</response>          
        /// <response code ="500">Internal error (exception).</response>
        [HttpPost]
        [Route("add")]
        [Authorize(policy: "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddUser([FromBody] UserInputModel inputModel)
        {            
            try
            {
                Log.Information("Add 'User' item request.");
                var user = await _userService.Create(inputModel);
                if (user is not null)
                {
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error occurs on try to add a 'User' item.");
                return StatusCode(500, "Internal error occurs.");
            }
            return BadRequest();
        }

        /// <summary>[HttpGet] User controller ShowUpdateForm method. 
        /// Get User item to update for the User Id in parameter.</summary>  
        /// <param name="id">User Id to get.</param>
        /// <returns>User item.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        /// <remarks>Route: /User/update/{id}.</remarks>
        /// <response code ="200">OK.</response>     
        /// <response code ="404">Not found.</response>
        /// <response code ="500">Internal error (exception).</response>
        [HttpGet]
        [Route("update/{id}")]
        [Authorize(policy: "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ShowUpdateForm(int id)
        {
            try
            {
                Log.Information("Get request of 'User' to update for id: {id}.", id);
                var user = _userService.Get(id);
                if (user is not null)
                {
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error occurs on try to 'User' item for id: {id}.", id);
                return StatusCode(500, "Internal error occurs.");
            }
            Log.Warning("'User' item not found for id: {id}.", id);
            return NotFound();
        }
        /// <summary>[HttpPost] User controller UpdateUser method. 
        /// Post update for the User Id and item in parameters.</summary>  
        /// <param name="id">User Id.</param>
        /// <param name="inputModel">User item.</param>
        /// <returns>Updated User list.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        /// <remarks>Route: /User/update/{id}.</remarks>
        /// <response code ="200">OK.</response>     
        /// <response code ="404">Not found.</response>
        /// <response code ="500">Internal error (exception).</response>
        [HttpPost]
        [Route("update/{id}")]
        [Authorize(policy: "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserInputModel inputModel)
        {
            Log.Information("Update request of 'User' item for id: {id}.", id);
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
                Log.Error(ex, "Internal error occurs on try to deleted 'User' item for id: {id}.", id);
                return StatusCode(500, "Internal error occurs.");
            }
            Log.Warning("'User' item not found for id: {id}.", id);
            return NotFound();
        }
        /// <summary>[HttpDelete] User controller DeleteUser method. 
        /// Delete User item for the Id in parameters.</summary>  
        /// <param name="id">User Id.</param>
        /// <returns>Updated User list.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        /// <remarks>Route: /User/delete/{id}.</remarks>
        /// <response code ="200">OK.</response>     
        /// <response code ="404">Not found.</response>
        /// <response code ="500">Internal error (exception).</response>
        [HttpDelete]
        [Route("{id}")]
        [Authorize(policy: "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                Log.Information("Delete request of 'User' item for id: {id}.", id);
                var user = await _userService.Delete(id);
                if (user is not null)
                {
                    return Ok(await _userService.List());
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error occurs on try to delete 'User' item for id: {id}.", id);
                return StatusCode(500, "Internal error occurs.");
            }
            Log.Warning("'User' item not found for id: {id}.", id);
            return NotFound();
        }
    }
}