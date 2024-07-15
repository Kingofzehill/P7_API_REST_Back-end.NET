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
    [Route("[controller]")]
    public class RuleNameController : ControllerBase
    {
        private readonly IRuleNameService _ruleNameService;
        public RuleNameController(IRuleNameService ruleNameService)
        {
            _ruleNameService = ruleNameService;
        }
        /// <summary>List Rule items.</summary>  
        /// <returns>Rule list.</returns> 
        /// <remarks>[HttpGet] Rule controller List method. 
        /// Authenticated and authorized User access only. 
        /// Route: /Rule/list.</remarks>
        /// <response code ="200">OK.</response>      
        /// <response code ="401">Unauthorized.</response>  
        /// <response code ="500">Internal error (exception).</response>
        [HttpGet]
        [Route("list")]
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
        /// <summary>Get Rule item for the Id in input. </summary>  
        /// <param name="id">Rule Id.</param>
        /// <returns>Selected Rule.</returns> 
        /// <remarks>[HttpGet] Rule controller Get method. 
        /// Authenticated and authorized User access only. 
        /// Route: /Rule/get/{id}.</remarks>
        /// <response code ="200">OK.</response>  
        /// <response code ="401">Unauthorized.</response>  
        /// <response code ="404">Not found.</response>
        /// <response code ="500">Internal error (exception).</response>
        [HttpGet]
        [Route("get/{id}")]
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
        /// <summary>Add a Rule item.</summary>  
        /// <param name="inputModel">Rule input model object.</param>
        /// <returns>Rule item created.</returns> 
        /// <remarks>[HttpPost] Rule controller AddRuleName method. 
        /// Authenticated and authorized User access only. 
        /// Route: /Rule/add.</remarks>
        /// <response code ="200">OK.</response>   
        /// <response code ="401">Unauthorized.</response>  
        /// <response code ="500">Internal error (exception).</response>
        [HttpPost]
        [Route("add")]
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
        /// <summary>Get Rule item to update for the Id in input.</summary>  
        /// <param name="id">Rule Id.</param>
        /// <returns>Rule item.</returns> 
        /// <remarks>[HttpGet] Rule controller ShowUpdateForm method. 
        /// Authenticated and authorized User access only. 
        /// Route: /Rule/update/{id}.</remarks>
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
        /// <summary>Post update for the Rule Id and item in input.</summary>  
        /// <param name="id">Rule Id.</param>
        /// <param name="inputModel">Rule input model object.</param>
        /// <returns>Updated Rule list.</returns> 
        /// <remarks>[HttpPost] Rule controller UpdateRuleName method. 
        /// Authenticated and authorized User access only. 
        /// Route: /Rule/update/{id}.</remarks>
        /// <response code ="200">OK.</response>   
        /// <response code ="401">Unauthorized.</response>  
        /// <response code ="404">Not found.</response>
        /// <response code ="500">Internal error (exception).</response>
        [HttpPost]
        [Route("update/{id}")]
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
        /// <summary>Delete Rule item for the Id in parameters.</summary>  
        /// <param name="id">Rule Id.</param>
        /// <returns>Updated Rule list.</returns> 
        /// <remarks>[HttpDelete] Rule controller DeleteRuleName method. 
        /// Authenticated and authorized User access only. 
        /// Route: /Rule/delete/{id}.</remarks>
        /// <response code ="200">OK.</response>   
        /// <response code ="401">Unauthorized.</response>  
        /// <response code ="404">Not found.</response>
        /// <response code ="500">Internal error (exception).</response>
        [HttpDelete]
        [Route("delete/{id}")]
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