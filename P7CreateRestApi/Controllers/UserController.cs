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
    [Route("Users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userRepository)
        {
            _userService = userRepository;
        }
        /// <summary>Get a list of User items. </summary>  
        /// <returns>User list.</returns> 
        /// <remarks>[HttpGet] User controller List method. 
        /// Authenticated and authorized Admin User access only. 
        /// URI: /User/list.</remarks>
        /// <response code ="200">OK.</response>       
        /// <response code ="401">Unauthorized.</response>    
        /// <response code ="500">Internal error (exception).</response>
        [HttpGet]
        [Route("")]
        [Authorize(policy: "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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

        /// <summary>Get the User item for the Id in input. </summary>  
        /// <param name="id">User Id.</param>
        /// <returns>Selected User.</returns> 
        /// <remarks>[HttpGet] User controller Get method. 
        /// Authenticated and authorized Admin User access only. 
        /// URI: /User/get/{id}.</remarks>
        /// <response code ="200">OK.</response>  
        /// <response code ="401">Unauthorized.</response>    
        /// <response code ="404">Not found.</response>
        /// <response code ="500">Internal error (exception).</response>
        [HttpGet]
        [Route("{id}")]
        [Authorize(policy: "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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

        /// <summary>Add the User item in input.</summary>  
        /// <param name="inputModel">User input model object.</param>
        /// <returns>User item created.</returns> 
        /// <remarks>[HttpPost] User controller AddUser method. 
        /// Authenticated and authorized Admin User access only. 
        /// URI: /User/add.</remarks>
        /// <response code ="200">OK.</response>    
        /// <response code ="401">Unauthorized.</response>    
        /// <response code ="500">Internal error (exception).</response>
        [HttpPost]
        [Route("")]
        [Authorize(policy: "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
        /* Redundant method with Get method, so commented out.
        /// <summary>Get the User item of the Id in input for an update.</summary>  
        /// <param name="id">User Id.</param>
        /// <returns>User item.</returns> 
        /// <remarks>[HttpGet] User controller ShowUpdateForm method. 
        /// Authenticated and authorized Admin User access only. 
        /// URI: /User/update/{id}.</remarks>
        /// <response code ="200">OK.</response>     
        /// <response code ="401">Unauthorized.</response>   
        /// <response code ="404">Not found.</response>
        /// <response code ="500">Internal error (exception).</response>
        [HttpGet]
        [Route("update/{id}")]
        [Authorize(policy: "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
        */
        /// <summary>User item update for the Id in input.</summary>  
        /// <param name="id">User Id.</param>
        /// <param name="inputModel">User input model object.</param>
        /// <returns>Updated User list.</returns> 
        /// <remarks>[HttpPost] User controller UpdateUser method. 
        /// Authenticated and authorized Admin User access only. 
        /// URI: /User/update/{id}.</remarks>
        /// <response code ="200">OK.</response>   
        /// <response code ="401">Unauthorized.</response>    
        /// <response code ="404">Not found.</response>
        /// <response code ="500">Internal error (exception).</response>
        [HttpPut]
        [Route("{id}")]
        [Authorize(policy: "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
        /// <summary>Delete the User item for the Id in input.</summary>  
        /// <param name="id">User Id.</param>
        /// <returns>Updated User list.</returns> 
        /// <remarks>[HttpDelete] User controller DeleteUser method. 
        /// Authenticated and authorized Admin User access only. 
        /// URI: /User/delete/{id}.</remarks>
        /// <response code ="200">OK.</response>   
        /// <response code ="401">Unauthorized.</response>    
        /// <response code ="404">Not found.</response>
        /// <response code ="500">Internal error (exception).</response>
        [HttpDelete]
        [Route("{id}")]
        [Authorize(policy: "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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