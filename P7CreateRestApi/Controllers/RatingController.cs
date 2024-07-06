// FIX01.01 Add using reference Dot.Net.WebApi.Domain to RuleName Controller
// for resolving unfound assembly reference Rating POCO Model.
using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Services;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;
        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }
        /// <summary>Rating controller List method. 
        /// Call Rating service, then Rating repertory,  
        /// get Rating POCO output model object list. </summary>  
        /// <remarks>Status code 500 in case of exception.</remarks>
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpGet]
        [Route("list")]
        [Authorize(policy: "User")]
        public IActionResult List()
        {
            try
            {
                return Ok(_ratingService.List());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Une erreur interne s'est produite");
            }
        }
        /// <summary>Rating controller Get method. 
        /// Call Rating service, then Rating repertory, 
        /// get Rating POCO output model object list for the Rating Id in parameter. </summary>  
        /// <remarks>Status code 500 in case of exception.</remarks>
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpGet]
        [Route("get/{id}")]
        [Authorize(policy: "User")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                var ratingService = _ratingService.Get(id);
                if (ratingService is not null)
                {
                    return Ok(ratingService);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }
        /// <summary>Rating controller AddRating method. 
        /// Call Rating service, then Rating repertory for create. 
        /// Returns Rating POCO output model object created for view. </summary>  
        /// <remarks>Status code 500 in case of exception.</remarks>
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpPost]
        [Route("add")]
        [Authorize(policy: "User")]
        public IActionResult AddRating([FromBody] RatingInputModel inputModel)
        {
            try
            {
                return Ok(_ratingService.Create(inputModel));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Une erreur interne s'est produite");
            }
        }
        /// <summary>Rating controller ShowUpdateForm method. 
        /// Call Rating service, then Rating repertory for Get. 
        /// Returns Rating POCO output model object created for update view. </summary>  
        /// <remarks>Status code 500 in case of exception.</remarks>
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpGet]
        [Route("update/{id}")]
        [Authorize(policy: "User")]
        public IActionResult ShowUpdateForm(int id)
        {
            try
            {
                var rating = _ratingService.Get(id);
                if (rating is not null)
                {
                    return Ok(rating);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }
        /// <summary>Rating controller UpdateRating method. 
        /// Call Rating service, then Rating repertory for Update following input ID in parameter. 
        /// Returns Rating POCO output model objects list for view. </summary>  
        /// <remarks>Status code 500 in case of exception.</remarks>
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpPost]
        [Route("update/{id}")]
        [Authorize(policy: "User")]
        public IActionResult UpdateRating([FromRoute] int id, [FromBody] RatingInputModel inputModel)
        {
            try
            {
                var rating = _ratingService.Update(id, inputModel);
                if (rating is not null)
                {
                    return Ok(_ratingService.List());
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }
        /// <summary>Rating controller DeleteRating method. 
        /// Call Rating service, then Rating repertory for Delete following input ID in parameter. 
        /// Returns Rating POCO output model object deleted for view. </summary>  
        /// <param name="id">Id of the Rating to delete</param>
        /// <remarks>Status code 500 in case of exception.</remarks>
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpDelete]
        [Route("delete/{id}")]
        [Authorize(policy: "User")]
        public IActionResult DeleteRating([FromRoute] int id)
        {
            try
            {
                var rating = _ratingService.Delete(id);
                if (rating is not null)
                {
                    return Ok(_ratingService.List());
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