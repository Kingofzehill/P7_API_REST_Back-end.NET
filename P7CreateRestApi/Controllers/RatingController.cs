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
        /// <summary>[HttpGet] Rating controller List method. 
        /// Call Rating service, then Rating repertory and 
        /// get Rating list. </summary>  
        /// <returns>Status code 200 (OK) with Rating list 
        /// OR error code 500 if exception.</returns> 
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
        /// <summary>[HttpGet] Rating controller Get method. 
        /// Call Rating service, then Rating repertory, and get Rating
        /// corresponding to Id in input parameter.</summary>     
        /// <param name="id">Id of the CurvePoint to get.</param>
        /// <returns>Status code 200 (OK) with Rating selected 
        /// OR error code 500 if exception.</returns> 
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
        /// <summary>[HttpPost] Rating controller AddRating method. 
        /// Call Rating service, then Rating repertory for create.</summary>  
        /// <param name="inputModel">POCO Rating input model class object.</param>
        /// <returns>Status code 200 (OK) with Rating created 
        /// OR error code 500 if exception.</returns> 
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
        /// <summary>[HttpGet] Rating controller ShowUpdateForm method. 
        /// Call Rating service, then Rating repertory and get Rating 
        /// corresponding to Id in input parameter.</summary>   
        /// <param name="id">Id of the Rating.</param>
        /// <returns>Status code 200 (OK) with selecting Rating 
        /// OR error code 500 if exception.</returns> 
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
        /// <summary>[HttpPost] Rating controller UpdateRating method. 
        /// Call Rating service, then Rating repertory and update Rating 
        /// corresponding to Id in input parameter</summary>  
        /// <param name="id">Id of the Rating to update.</param>
        /// <param name="inputModel">POCO Rating input model class object.</param>
        /// <returns>Status code 200 (OK) with updated Rating list 
        /// OR error code 500 if exception.</returns> 
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
        /// <summary>[HttpDelete] Rating controller DeleteRating method. 
        /// Call Rating service, then Rating repertory and 
        /// delete Rating corresponding to Id in input parameter.</summary> 
        /// <param name="id">Id of the Rating to delete</param>
        /// <returns>Status code 200 (OK) with remaining Rating list 
        /// OR error code 500 if exception.</returns> 
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