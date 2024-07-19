using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Services;
using Serilog;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("Trades")]
    public class TradeController : ControllerBase
    {
        private readonly ITradeService _tradeService;
        public TradeController(ITradeService tradeService)
        {
            _tradeService = tradeService;
        }

        /// <summary>Get a list of Trade items.</summary>  
        /// <returns>Trade list.</returns> 
        /// <remarks>[HttpGet] Trade controller List method. 
        /// Authenticated and authorized User access only. 
        /// URI: /Trade/list.</remarks>
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
                Log.Information("'Trade' list request.");
                return Ok(_tradeService.List());
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error (500) occurs on 'Trade' list request.");
                return StatusCode(500, "Internal error occurs.");
            }
        }

        /// <summary>Get the Trade item for the Id in input. </summary>  
        /// <param name="id">Trade Id.</param>
        /// <returns>Selected Trade.</returns> 
        /// <remarks>[HttpGet] Trade controller Get method. 
        /// Authenticated and authorized User access only. 
        /// URI: /Trade/get/{id}.</remarks>
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
            Log.Information("Get request of 'Trade' for id: {id}.", id);
            try
            {
                var trade = _tradeService.Get(id);
                if (trade is not null)
                {
                    return Ok(trade);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error occurs on try to get 'Trade' for id: {id}.", id);
                return StatusCode(500, "Internal error occurs.");
            }
            Log.Warning("'Trade' item not found for id: {id}.", id);
            return NotFound();
        }
        /// <summary>Add the Trade item in input.</summary>  
        /// <param name="inputModel">Trade input model object.</param>
        /// <returns>Trade item created.</returns> 
        /// <remarks>[HttpPost] Trade controller AddTrade method. 
        /// Authenticated and authorized User access only. 
        /// URI: /Trade/add.</remarks>
        /// <response code ="200">OK.</response>  
        /// <response code ="401">Unauthorized.</response>   
        /// <response code ="500">Internal error (exception).</response>
        [HttpPost]
        [Route("")]
        [Authorize(policy: "User")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddTrade([FromBody] TradeInputModel inputModel)
        {            
            try
            {
                Log.Information("Add 'Trade' item request.");
                return Ok(_tradeService.Create(inputModel));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error occurs on try to add a 'Trade' item.");
                return StatusCode(500, "Internal error occurs.");
            }
        }
        /* Redundant method with Get method, so commented out.
        /// <summary>Get the Trade item of the Id in input for an update.</summary>  
        /// <param name="id">Trade Id.</param>
        /// <returns>Trade item.</returns> 
        /// <remarks>[HttpGet] Trade controller ShowUpdateForm method. 
        /// Authenticated and authorized User access only. 
        /// URI: /Trade/update/{id}.</remarks>
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
            Log.Information("Get request of 'Trade' to update for id: {id}.", id);
            try
            {
                var trade = _tradeService.Get(id);
                if (trade is not null)
                {
                    return Ok(trade);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error occurs on try to 'Trade' item for id: {id}.", id);
                return StatusCode(500, "Internal error occurs.");
            }
            Log.Warning("'Trade' item not found for id: {id}.", id);
            return NotFound();
        }
        */
        /// <summary>Trade item update for the Id in input.</summary>  
        /// <param name="id">Trade Id.</param>
        /// <param name="inputModel">Trade input model object.</param>
        /// <returns>Updated Trade list.</returns> 
        /// <remarks>[HttpPost] Trade controller UpdateTrade method. 
        /// Authenticated and authorized User access only. 
        /// URI: /Trade/update/{id}.</remarks>
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
        public IActionResult UpdateTrade([FromRoute] int id, [FromBody] TradeInputModel inputModel)
        {
            Log.Information("Update request of 'Trade' item for id: {id}.", id);
            try
            {
                var trade = _tradeService.Update(id, inputModel);
                if (trade is not null)
                {
                    return Ok(_tradeService.List());
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error occurs on try to deleted 'Trade' item for id: {id}.", id);
                return StatusCode(500, "Internal error occurs.");
            }
            Log.Warning("'Trade' item not found for id: {id}.", id);
            return NotFound();
        }
        /// <summary>Delete the Trade item for the Id in input.</summary>  
        /// <param name="id">Trade Id.</param>
        /// <returns>Updated Trade list.</returns> 
        /// <remarks>[HttpDelete] Trade controller DeleteTrade method. 
        /// Authenticated and authorized User access only. 
        /// URI: /Trade/delete/{id}.</remarks>
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
        public IActionResult DeleteTrade([FromRoute] int id)
        {
            try
            {
                Log.Information("Delete request of 'Trade' item for id: {id}.", id);
                var trade = _tradeService.Delete(id);
                if (trade is not null)
                {
                    return Ok(_tradeService.List());
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error occurs on try to delete 'Trade' item for id: {id}.", id);
                return StatusCode(500, "Internal error occurs.");
            }
            Log.Warning("'Trade' item not found for id: {id}.", id);
            return NotFound();
        }
    }
}