using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Services;
using Serilog;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurveController : ControllerBase
    {
        private readonly ICurvePointService _curvePointService;
        public CurveController(ICurvePointService curvePointService)
        {
            _curvePointService = curvePointService;
        }

        /// <summary>List CurvePoint items. </summary>  
        /// <returns>CurvePoint list.</returns> 
        /// <remarks>[HttpGet] CurvePoint controller List method. 
        /// Authenticated and authorized User access only. 
        /// Route: /Curve/list.</remarks>
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
                Log.Information("'CurvePoint' list request.");
                return Ok(_curvePointService.List());
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error (500) occurs on 'CurvePoint' list request.");
                return StatusCode(500, "Internal error occurs.");
            }
        }

        /// <summary>Get CurvePoint item for the Id in input. </summary>     
        /// <param name="id">CurvePoint Id.</param>
        /// <returns>Selected CurvePoint.</returns> 
        /// <remarks>[HttpGet] CurvePoint controller Get method. 
        /// Authenticated and authorized User access only. 
        /// Route: /Curve/get/{id}.</remarks>
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
            try
            {
                Log.Information("Get request of 'CurvePoint' for id: {id}.", id);
                var curvePoint = _curvePointService.Get(id);
                if (curvePoint is not null)
                {
                    return Ok(curvePoint);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error occurs on try to get 'CurvePoint' for id: {id}.", id);
                return StatusCode(500, "Internal error occurs.");
            }
            Log.Warning("'CurvePoint' item not found for id: {id}.", id);
            return NotFound();
        }

        /// <summary>Add a CurvePoint item.</summary>
        /// <param name="inputModel">CurvePoint input model object.</param>
        /// <returns>CurvePoint item created.</returns> 
        /// <remarks>[HttpPost] CurvePoint controller AddCurvePoint method. 
        /// Authenticated and authorized User access only. 
        /// Route: /Curve/add.</remarks>
        /// <response code ="200">OK.</response>      
        /// <response code ="401">Unauthorized.</response>  
        /// <response code ="500">Internal error (exception).</response>
        [HttpPost]
        [Route("add")]
        [Authorize(policy: "User")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddCurvePoint([FromBody] CurvePointInputModel inputModel)
        {
            try
            {
                Log.Information("Add 'CurvePoint' item request.");
                return Ok(_curvePointService.Create(inputModel));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error occurs on try to add a 'CurvePoint' item.");
                return StatusCode(500, "Internal error occurs.");
            }
        }
        /// <summary>Get CurvePoint item to update for the Id in input.</summary>   
        /// <param name="id">CurvePoint Id to get.</param>
        /// <returns>CurvePoint item..</returns> 
        /// <remarks>[HttpGet] CurvePoint controller ShowUpdateForm method. 
        /// Authenticated and authorized User access only. 
        /// Route: /Curve/update/{id}.</remarks>
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
            Log.Information("Get request of 'CurvePoint' to update for id: {id}.", id);
            try
            {
                var curvePoint = _curvePointService.Get(id);
                if (curvePoint is not null)
                {
                    return Ok(curvePoint);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error occurs on try to 'CurvePoint' item for id: {id}.", id);
                return StatusCode(500, "Internal error occurs.");
            }
            Log.Warning("'CurvePoint' item not found for id: {id}.", id);
            return NotFound();
        }
        /// <summary>Post update for the CurvePoint Id and item in input.</summary>  
        /// <param name="id">CurvePoint Id.</param>
        /// <param name="inputModel">CurvePoint input model object.</param>
        /// <returns>Updated CurvePoint list.</returns> 
        /// <remarks>[HttpPost] CurvePoint controller UpdateCurvePoint method. 
        /// Authenticated and authorized User access only. 
        /// Route: /Curve/update/{id}.</remarks>
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
        public IActionResult UpdateCurvePoint([FromRoute] int id, [FromBody] CurvePointInputModel inputModel)
        {
            Log.Information("Update request of 'CurvePoint' item for id: {id}.", id);
            try
            {
                var curvePoint = _curvePointService.Update(id, inputModel);
                if (curvePoint is not null)
                {
                    return Ok(_curvePointService.List());
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error occurs on try to deleted 'CurvePoint' item for id: {id}.", id);
                return StatusCode(500, "Internal error occurs.");
            }
            Log.Warning("'CurvePoint' item not found for id: {id}.", id);
            return NotFound();
        }

        /// <summary>Delete CurvePoint item for the Id in input.</summary>  
        /// <param name="id">CurvePoint Id.</param>
        /// <returns>Updated CurvePoint list.</returns> 
        /// <remarks>[HttpDelete] CurvePoint controller DeleteCurvePoint method. 
        /// Authenticated and authorized User access only. 
        /// Route: /Curve/delete/{id}.</remarks>
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
        public IActionResult DeleteCurvePoint(int id)
        {
            Log.Information("Delete request of 'CurvePoint' item for id: {id}.", id);
            try
            {
                var curvePoint = _curvePointService.Delete(id);
                if (curvePoint is not null)
                {
                    return Ok(_curvePointService.List());
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Internal error occurs on try to delete 'CurvePoint' item for id: {id}.", id);
                return StatusCode(500, "Internal error occurs.");
            }
            Log.Warning("'CurvePoint' item not found for id: {id}.", id);
            return NotFound();
        }
    }
}