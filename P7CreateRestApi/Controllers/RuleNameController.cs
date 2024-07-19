// FIX01 Add using reference Dot.Net.WebApi.Domain to RuleName Controller.
// for resolving unfound assembly reference RuleName POCO Model
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Services;
using Serilog;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("RuleNames")]
    public class RuleNameController : ControllerBase
    {
        private readonly IRuleNameService _ruleNameService;
        public RuleNameController(IRuleNameService ruleNameService)
        {
            _ruleNameService = ruleNameService;
        }
        /// <summary>Get a list of RuleName items.</summary>  
        /// <returns>RuleName list.</returns> 
        /// <remarks>[HttpGet] RuleName controller List method. 
        /// Authenticated and authorized User access only. 
        /// URI: /RuleName/list.</remarks>
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
                Log.Information("'Rule' list request.");
                return Ok(_ruleNameService.List());
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error (500) occurs on 'Rule' list request.");
                return StatusCode(500, "Internal error occurs.");
            }
        }
        /// <summary>Get the RuleName item for the Id in input. </summary>  
        /// <param name="id">RuleName Id.</param>
        /// <returns>Selected RuleName.</returns> 
        /// <remarks>[HttpGet] RuleName controller Get method. 
        /// Authenticated and authorized User access only. 
        /// URI: /RuleName/get/{id}.</remarks>
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
            Log.Information("Get request of 'Rule' for id: {id}.", id);
            try
            {
                var ruleName = _ruleNameService.Get(id);
                if (ruleName is not null)
                {
                    return Ok(ruleName);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error occurs on try to get 'Rule' for id: {id}.", id);
                return StatusCode(500, "Internal error occurs.");
            }
            Log.Warning("'Rule' item not found for id: {id}.", id);
            return NotFound();
        }
        /// <summary>Add the RuleName item in input.</summary>  
        /// <param name="inputModel">RuleName input model object.</param>
        /// <returns>RuleName item created.</returns> 
        /// <remarks>[HttpPost] RuleName controller AddRuleName method. 
        /// Authenticated and authorized User access only. 
        /// URI: /RuleName/add.</remarks>
        /// <response code ="200">OK.</response>   
        /// <response code ="401">Unauthorized.</response>  
        /// <response code ="500">Internal error (exception).</response>
        [HttpPost]
        [Route("")]
        [Authorize(policy: "User")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddRuleName([FromBody] RuleNameInputModel inputModel)
        {           
            try
            {
                Log.Information("Add 'Rule' item request.");
                return Ok(_ruleNameService.Create(inputModel));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error occurs on try to add a 'Rule' item.");
                return StatusCode(500, "Internal error occurs.");
            }
        }
        /* Redundant method with Get method, so commented out.
        /// <summary>Get the RuleName item of the Id in input for an update.</summary>  
        /// <param name="id">RuleName Id.</param>
        /// <returns>RuleName item.</returns> 
        /// <remarks>[HttpGet] RuleName controller ShowUpdateForm method. 
        /// Authenticated and authorized User access only. 
        /// URI: /RuleName/update/{id}.</remarks>
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
            Log.Information("Get request of 'Rule' to update for id: {id}.", id);
            try
            {
                var ruleName = _ruleNameService.Get(id);
                if (ruleName is not null)
                {
                    return Ok(ruleName);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error occurs on try to 'Rule' item for id: {id}.", id);
                return StatusCode(500, "Internal error occurs.");
            }
            Log.Warning("'Rule' item not found for id: {id}.", id);
            return NotFound();
        }
        */
        /// <summary>RuleName item update for the Id in input.</summary>  
        /// <param name="id">RuleName Id.</param>
        /// <param name="inputModel">RuleName input model object.</param>
        /// <returns>Updated RuleName list.</returns> 
        /// <remarks>[HttpPost] RuleName controller UpdateRuleName method. 
        /// Authenticated and authorized User access only. 
        /// URI: /RuleName/update/{id}.</remarks>
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
        public IActionResult UpdateRuleName([FromRoute] int id, [FromBody] RuleNameInputModel inputModel)
        {
            Log.Information("Update request of 'Rule' item for id: {id}.", id);
            try
            {
                var ruleName = _ruleNameService.Update(id, inputModel);
                if (ruleName is not null)
                {
                    return Ok(_ruleNameService.List());
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error occurs on try to deleted 'Rule' item for id: {id}.", id);
                return StatusCode(500, "Internal error occurs.");
            }
            Log.Warning("'Rule' item not found for id: {id}.", id);
            return NotFound();
        }
        /// <summary>Delete the RuleName item for the Id in input.</summary>  
        /// <param name="id">RuleName Id.</param>
        /// <returns>Updated RuleName list.</returns> 
        /// <remarks>[HttpDelete] RuleName controller DeleteRuleName method. 
        /// Authenticated and authorized User access only. 
        /// URI: /RuleName/delete/{id}.</remarks>
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
        public IActionResult DeleteRuleName([FromRoute] int id)
        {            
            try
            {
                Log.Information("Delete request of 'Rule' item for id: {id}.", id);
                var ruleName = _ruleNameService.Delete(id);
                if (ruleName is not null)
                {                    
                    return Ok(_ruleNameService.List());
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error occurs on try to delete 'Rule' item for id: {id}.", id);
                return StatusCode(500, "Internal error occurs.");
            }
            Log.Warning("'Rule' item not found for id: {id}.", id);
            return NotFound();
        }
    }
}