using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Services;

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

        /// <summary>[HttpGet] CurvePoint controller List method. 
        /// Call CurvePoint service, then CurvePoint repertory,  
        /// get CurvePoint list. </summary>  
        /// <returns>Status code 200 (OK) with CurvePoint list 
        /// OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpGet]
        [Route("list")]
        [Authorize(policy: "User")]
        public IActionResult List()
        {            
            try
            {
                return Ok(_curvePointService.List());
            }
            catch (Exception ex)
            {                
                return StatusCode(500, "Une erreur interne s'est produite");
            }
        }

        /// <summary>[HttpGet] CurvePoint controller Get method. 
        /// Call CurvePoint service, then CurvePoint repertory, and get Curvepoint
        /// corresponding to Id in input parameter.</summary>    
        /// <param name="id">Id of the CurvePoint to get.</param>
        /// <returns>Status code 200 (OK) with CurvePoint get 
        /// OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpGet]
        [Route("get/{id}")]
        [Authorize(policy: "User")]
        public IActionResult Get([FromRoute] int id)
        {
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
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }

        /// <summary>[HttpPost] CurvePoint controller AddCurvePoint method. 
        /// Call CurvePoint service, then CurvePoint repertory for create.</summary> 
        /// <param name="inputModel">POCO CurvePoint input model class object.</param>
        /// <returns>Status code 200 (OK) with CurvePoint created 
        /// OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpPost]
        [Route("add")]
        [Authorize(policy: "User")]
        public IActionResult AddCurvePoint([FromBody] CurvePointInputModel inputModel)
        {
            try
            {
                return Ok(_curvePointService.Create(inputModel));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Une erreur interne s'est produite");
            }
        }
        /// <summary>[HttpGet] CurvePoint controller ShowUpdateForm method. 
        /// Call CurvePoint service, then CurvePoint repertory and get Curvepoint 
        /// corresponding to Id in input parameter.</summary>   
        /// <param name="id">Id of the CurvePoint to show.</param>
        /// <returns>Status code 200 (OK) with CurvePoint selected 
        /// OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpGet]
        [Route("update/{id}")]
        [Authorize(policy: "User")]
        public IActionResult ShowUpdateForm(int id)
        {
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
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }
        /// <summary>[HttpPost] CurvePoint controller UpdateCurvePoint method. 
        /// Call CurvePoint service, then CurvePoint repertory and update CurvePoint 
        /// corresponding to Id in input parameter.</summary>  
        /// <param name="id">Id of the CurvePoint to update.</param>
        /// <param name="inputModel">POCO CurvePoint input model class object.</param>
        /// <returns>Status code 200 (OK) with remaining CurvePoint list 
        /// OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpPost]
        [Route("update/{id}")]
        [Authorize(policy: "User")]
        public IActionResult UpdateCurvePoint([FromRoute] int id, [FromBody] CurvePointInputModel inputModel)
        {
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
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();

        }

        /// <summary>[HttpDelete] CurvePoint controller DeleteCurvePoint method. 
        /// Call CurvePoint service, then CurvePoint repertory and 
        /// delete CurvePoint corresponding to Id in input parameter.</summary> 
        /// <param name="id">Id of the CurvePoint to delete.</param>
        /// <returns>Status code 200 (OK) with remaining CurvePoint list 
        /// OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpDelete]
        [Route("delete/{id}")]
        [Authorize(policy: "User")]
        public IActionResult DeleteCurvePoint(int id)
        {
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
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }
    }
}