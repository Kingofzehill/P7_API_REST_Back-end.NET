// FIX01.01 Add using reference Dot.Net.WebApi.Domain to RuleName Controller
// for resolving unfound assembly reference Rating POCO Model.
using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Services;
using Serilog;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("Ratings")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;
        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }
        /// <summary>Get a list of Rating items.</summary> 
        /// <returns>Rating list.</returns> 
        /// <remarks>[HttpGet] Rating controller List method. 
        /// Authenticated and authorized User access only. 
        /// URI: /Rating/list.</remarks>
        /// <response code ="200">OK.</response>    
        /// <response code ="401">Unauthorized.</response> 
        /// <response code ="500">Internal error (exception).</response>
        [HttpGet]
        [Route("")]
        [Authorize(policy: "User")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult List()
        {
            try
            {
                Log.Information("'Rating' list request.");
                return Ok(_ratingService.List());
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error (500) occurs on 'Rating' list request.");
                return StatusCode(500, "Internal error occurs.");
            }
        }
        /// <summary>Get the Rating item for the Id in input. </summary>  
        /// <param name="id">Rating Id.</param>
        /// <returns>Selected Rating.</returns>
        /// <remarks>[HttpGet] Rating controller Get method. 
        /// Authenticated and authorized User access only. 
        /// URI: /Rating/get/{id}.</remarks>
        /// <response code ="200">OK.</response>  
        /// <response code ="401">Unauthorized.</response> 
        /// <response code ="404">Not found.</response>
        /// <response code ="500">Internal error (exception).</response>
        [HttpGet]
        [Route("{id}")]
        [Authorize(policy: "User")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get([FromRoute] int id)
        {
            Log.Information("Get request of 'Rating' for id: {id}.", id);
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
                Log.Error(ex, "Internal error occurs on try to get 'Rating' for id: {id}.", id);
                return StatusCode(500, "Internal error occurs.");
            }
            Log.Warning("'Rating' item not found for id: {id}.", id);
            return NotFound();
        }
        /// <summary>Add the Rating item in input.</summary>  
        /// <param name="inputModel">Rating input model object.</param>
        /// <returns>Rating item created.</returns> 
        /// <remarks>[HttpPost] Rating controller AddRating method. 
        /// Authenticated and authorized User access only. 
        /// URI: /Rating/add.</remarks>
        /// <response code ="200">OK.</response>  
        /// <response code ="401">Unauthorized.</response> 
        /// <response code ="500">Internal error (exception).</response>
        [HttpPost]
        [Route("")]
        [Authorize(policy: "User")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddRating([FromBody] RatingInputModel inputModel)
        {
            try
            {
                Log.Information("Add 'Rating' item request.");
                return Ok(_ratingService.Create(inputModel));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error occurs on try to add a 'Rating' item.");
                return StatusCode(500, "Internal error occurs.");
            }
        }
        /* Redundant method with Get method, so commented out.
        /// <summary>Get the Rating item of the Id in input for an update.</summary>  
        /// <param name="id">Rating Id.</param>
        /// <returns>Rating item.</returns> 
        /// <remarks>[HttpGet] Rating controller ShowUpdateForm method. 
        /// Authenticated and authorized User access only. 
        /// URI: /Rating/update/{id}.</remarks>
        /// <response code ="200">OK.</response>     
        /// <response code ="401">Unauthorized.</response> 
        /// <response code ="404">Not found.</response>
        /// <response code ="500">Internal error (exception).</response>
        [HttpGet]
        [Route("update/{id}")]
        [Authorize(policy: "User")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ShowUpdateForm(int id)
        {
            Log.Information("Get request of 'Rating' to update for id: {id}.", id);
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
                Log.Error(ex, "Internal error occurs on try to 'Rating' item for id: {id}.", id);
                return StatusCode(500, "Internal error occurs.");
            }
            Log.Warning("'Rating' item not found for id: {id}.", id);
            return NotFound();
        }
        */
        /// <summary>Rating item update for the Id in input.</summary>  
        /// <param name="id">Rating Id.</param>
        /// <param name="inputModel">Rating input model object.</param>
        /// <returns>Updated Rating list.</returns> 
        /// <remarks>[HttpPost] Rating controller UpdateRating method. 
        /// Authenticated and authorized User access only. 
        /// URI: /Rating/update/{id}.</remarks>
        /// <response code ="200">OK.</response>     
        /// <response code ="401">Unauthorized.</response> 
        /// <response code ="404">Not found.</response>
        /// <response code ="500">Internal error (exception).</response>
        [HttpPut]
        [Route("{id}")]
        [Authorize(policy: "User")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateRating([FromRoute] int id, [FromBody] RatingInputModel inputModel)
        {
            Log.Information("Update request of 'Rating' item for id: {id}.", id);
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
                Log.Error(ex, "Internal error occurs on try to deleted 'Rating' item for id: {id}.", id);
                return StatusCode(500, "Internal error occurs.");
            }
            Log.Warning("'Rating' item not found for id: {id}.", id);
            return NotFound();
        }
        /// <summary>Delete the Rating item for the Id in input.</summary>  
        /// <param name="id">Rating Id.</param>
        /// <returns>Updated Rating list.</returns> 
        /// <remarks>[HttpDelete] Rating controller DeleteRating method. 
        /// Authenticated and authorized User access only. 
        /// URI: /Rating/delete/{id}.</remarks>
        /// <response code ="200">OK.</response>   
        /// <response code ="401">Unauthorized.</response> 
        /// <response code ="404">Not found.</response>
        /// <response code ="500">Internal error (exception).</response>
        [HttpDelete]
        [Route("{id}")]
        [Authorize(policy: "User")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteRating([FromRoute] int id)
        {
            try
            {
                Log.Information("Delete request of 'Rating' item for id: {id}.", id);
                var rating = _ratingService.Delete(id);
                if (rating is not null)
                {
                    return Ok(_ratingService.List());
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error occurs on try to delete 'Rating' item for id: {id}.", id);
                return StatusCode(500, "Internal error occurs.");
            }
            Log.Warning("'Rating' item not found for id: {id}.", id);
            return NotFound();
        }
    }
}