using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models.InputModels;
using P7CreateRestApi.Services;
using Serilog;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BidListController : ControllerBase
    {
        private readonly IBidListService _bidListService;
        public BidListController(IBidListService bidListService)
        {
            _bidListService = bidListService;
        }

        /// <summary>[HttpGet] BidList controller List method. 
        /// Get BidList items list. </summary>  
        /// <returns>BidList list.</returns> 
        /// <remarks>Authenticated and authorized User access only.</remarks>
        /// <remarks>Route: /BidList/list.</remarks>
        /// <response code ="200">OK.</response>        
        /// <response code ="500">Internal error (exception).</response>
        [HttpGet]
        [Route("list")]
        [Authorize(policy: "User")]
        [ProducesResponseType(StatusCodes.Status200OK)]
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

        /// <summary>[HttpGet] BidList controller Get method. 
        /// Get BidList item for the BidList Id in parameter. </summary>  
        /// <param name="id">BidList Id.</param>
        /// <returns>Selected BidList.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        /// <remarks>Route: /BidList/get/{id}.</remarks>
        /// <response code ="200">OK.</response>  
        /// <response code ="404">Not found.</response>
        /// <response code ="500">Internal error (exception).</response>
        [HttpGet]
        [Route("get/{id}")]
        [Authorize(policy: "User")]
        [ProducesResponseType(StatusCodes.Status200OK)]
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

        /// <summary>[HttpPost] BidList controller AddBidList method. 
        /// Add a Bidlist item. </summary>  
        /// <param name="inputModel">BidList to add.</param>
        /// <returns>BidList item created.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        /// <remarks>Route: /BidList/add.</remarks>
        /// <response code ="200">OK.</response>          
        /// <response code ="500">Internal error (exception).</response>
        [HttpPost]
        [Route("add")]
        [Authorize(policy: "User")]
        [ProducesResponseType(StatusCodes.Status200OK)]        
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

        /// <summary>[HttpGet] BidList controller ShowUpdateForm method. 
        /// Get BidList item to update for the BidList Id in parameter.</summary>  
        /// <param name="id">BidList Id to get.</param>
        /// <returns>BidList item.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        /// <remarks>Route: /BidList/update/{id}.</remarks>
        /// <response code ="200">OK.</response>     
        /// <response code ="404">Not found.</response>
        /// <response code ="500">Internal error (exception).</response>
        [HttpGet]
        [Route("update/{id}")]
        [Authorize(policy: "User")]
        [ProducesResponseType(StatusCodes.Status200OK)]
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

        /// <summary>[HttpPost] BidList controller UpdateBid method. 
        /// Post update for the BidList Id and item in parameters.</summary>  
        /// <param name="id">BidList Id.</param>
        /// <param name="inputModel">BidList item.</param>
        /// <returns>Updated BidList list.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        /// <remarks>Route: /BidList/update/{id}.</remarks>
        /// <response code ="200">OK.</response>     
        /// <response code ="404">Not found.</response>
        /// <response code ="500">Internal error (exception).</response>
        [HttpPost]
        [Route("update/{id}")]
        [Authorize(policy: "User")]
        [ProducesResponseType(StatusCodes.Status200OK)]
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

        /// <summary>[HttpDelete] BidList controller DeleteBid method. 
        /// Delete BidList item for the Id in parameters.</summary>  
        /// <param name="id">BidList Id.</param>
        /// <returns>Updated BidList list.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        /// <remarks>Route: /BidList/delete/{id}.</remarks>
        /// <response code ="200">OK.</response>     
        /// <response code ="404">Not found.</response>
        /// <response code ="500">Internal error (exception).</response>
        [HttpDelete]
        [Route("delete/{id}")]
        [Authorize(policy: "User")]
        [ProducesResponseType(StatusCodes.Status200OK)]
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