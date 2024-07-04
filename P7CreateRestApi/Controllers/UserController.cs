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
        /// <summary>User controller List method. 
        /// Call User service, then User repertory</summary>  
        /// <returns>POCO User output model class objects list or error code 500.</returns>
        /// <remarks></remarks>
        [HttpGet]
        [Route("list")]
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
        /// <summary>User controller AddUser method. 
        /// Call User service, then User repertory for create. 
        /// <returns>POCO User output model class object or error code 500.</returns> 
        /// <remarks></remarks>
        [HttpGet]
        [Route("add")]
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

        /// <summary>User controller ShowUpdateForm method. 
        /// Call User service, then User repertory for Get. 
        /// <returns>POCO User output model class object or error code 500.</returns> 
        /// <remarks></remarks>
        [HttpGet]
        [Route("update/{id}")]
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
        /// <summary>User controller UpdateUser method. 
        /// Call User service, then User repertory for Update following input ID in parameter. 
        /// <returns>POCO User output model class object or error code 500.</returns> 
        /// <remarks></remarks>
        [HttpPost]
        [Route("update/{id}")]
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
        /// <summary>User controller DeleteUser method. 
        /// Call User service, then User repertory for Delete following input ID in parameter.</summary>  
        /// <param name="id">Id of the User to delete</param>
        /// <returns>POCO User output model class object or error code 500.</returns> 
        /// <remarks></remarks>
        [HttpDelete]
        [Route("{id}")]
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

        /// <summary>[HttpGet] User controller GetAllUserArticles method. 
        /// Call User service, then User repertory.</summary>  
        /// <returns>POCO User output model class objects list or error code 500.</returns>
        /// <remarks>Route("/secure/article-details")</remarks>
        [HttpGet]
        [Route("/secure/article-details")]
        public async Task<ActionResult<List<User>>> GetAllUserArticles()
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
    }
}