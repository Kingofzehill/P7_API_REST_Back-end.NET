using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models.InputModels;
using P7CreateRestApi.Services;
using Serilog;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("BidLists")]
    public class BidListController : ControllerBase
    {
        private readonly IBidListService _bidListService;
        public BidListController(IBidListService bidListService)
        {
            _bidListService = bidListService;
        }

        /// <summary>Get a list of BidList items.</summary>  
        /// <returns>BidList list.</returns> 
        /// <remarks>[HttpGet] BidList controller List method.
        /// Authenticated and authorized User access only.
        /// URI: /BidLists.</remarks>
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
                Log.Information("'BidList' list request.");
                return Ok(_bidListService.List());
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error (500) occurs on 'BidList' list request.");
                return StatusCode(500, "Internal error occurs.");
            }
        }

        /// <summary>Get the BidList item of the Id in input.</summary>  
        /// <param name="id">BidList Id.</param>
        /// <returns>Selected BidList.</returns> 
        /// <remarks>[HttpGet] BidList controller Get method. 
        /// Authenticated and authorized User access only.
        /// URI: /BidLists/{id}.</remarks>
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
            Log.Information("Get request of 'BidList' for id: {id}.", id);
            try
            {
                var bidList = _bidListService.Get(id);
                if (bidList is not null)
                {
                    return Ok(bidList);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error occurs on try to get 'BidList' for id: {id}.", id);
                return StatusCode(500, "Internal error occurs.");
            }
            Log.Warning("'BidList' item not found for id: {id}.", id);
            return NotFound();
        }

        /// <summary>Add the Bidlist item in input.</summary>  
        /// <param name="inputModel">BidList input model object.</param>
        /// <returns>BidList item created.</returns> 
        /// <remarks>[HttpPost] BidList controller AddBidList method.
        /// Authenticated and authorized User access only.
        /// URI: /BidLists.</remarks>
        /// <response code ="200">OK.</response>    
        /// <response code ="401">Unauthorized.</response>   
        /// <response code ="500">Internal error (exception).</response>
        [HttpPost]
        [Route("")]
        [Authorize(policy: "User")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddBidList([FromBody] BidListInputModel inputModel)
        {
            try
            {
                Log.Information("Add 'BidList' item request.");
                return Ok(_bidListService.Create(inputModel));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error occurs on try to add a 'BidList' item.");
                return StatusCode(500, "Internal error occurs.");
            }
        }

        /* Redundant method with Get method, so commented out.
        /// <summary>Get the BidList item of the Id in input for an update.</summary>  
        /// <param name="id">BidList Id.</param>
        /// <returns>BidList item.</returns> 
        /// <remarks>[HttpGet] BidList controller ShowUpdateForm method. 
        /// Authenticated and authorized User access only.
        /// URI: /BidLists/{id}.</remarks>
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
            Log.Information("Get request of 'BidList' to update for id: {id}.", id);
            try
            {
                var bidList = _bidListService.Get(id);
                if (bidList is not null)
                {
                    return Ok(bidList);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error occurs on try to 'BidList' item for id: {id}.", id);
                return StatusCode(500, "Internal error occurs.");
            }
            Log.Warning("'BidList' item not found for id: {id}.", id);
            return NotFound();
        }
        */

        /// <summary>BidList item update for the Id in input.</summary>  
        /// <param name="id">BidList Id.</param>
        /// <param name="inputModel">BidList input model object.</param>
        /// <returns>Updated BidList list.</returns> 
        /// <remarks>[HttpPost] BidList controller UpdateBid method.
        /// Authenticated and authorized User access only.
        /// URI: /BidLists/{id}.</remarks>
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
        public IActionResult UpdateBid(int id, [FromBody] BidListInputModel inputModel)
        {
            Log.Information("Update request of 'BidList' item for id: {id}.", id);
            try
            {
                var bidList = _bidListService.Update(id, inputModel);
                if (bidList is not null)
                {
                    return Ok(_bidListService.List());
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error occurs on try to deleted 'BidList' item for id: {id}.", id);
                return StatusCode(500, "Internal error occurs.");
            }
            Log.Warning("'BidList' item not found for id: {id}.", id);
            return NotFound();
        }

        /// <summary>Delete the BidList item for the Id in input.</summary>  
        /// <param name="id">BidList Id.</param>
        /// <returns>Updated BidList list.</returns> 
        /// <remarks>[HttpDelete] BidList controller DeleteBid method.
        /// Authenticated and authorized User access only.
        /// URI: /BidLists/{id}.</remarks>
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
        public IActionResult DeleteBid(int id)
        {
            try
            {
                Log.Information("Delete request of 'BidList' item for id: {id}.", id);
                var bidList = _bidListService.Delete(id);
                if (bidList is not null)
                {
                    return Ok(_bidListService.List());
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error occurs on try to delete 'BidList' item for id: {id}.", id);
                return StatusCode(500, "Internal error occurs.");
            }
            Log.Warning("'BidList' item not found for id: {id}.", id);
            return NotFound();
        }
    }
}