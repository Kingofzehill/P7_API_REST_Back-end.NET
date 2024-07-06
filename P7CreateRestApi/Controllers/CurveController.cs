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

        /// <summary>CurvePoint controller List method. 
        /// Call CurvePoint service, then CurvePoint repertory,  
        /// get CurvePoint POCO output model object list. </summary>  
        /// <remarks>Status code 500 in case of exception.</remarks>
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

        /// <summary>CurvePoint controller Get method. 
        /// Call CurvePoint service, then CurvePoint repertory, 
        /// get CurvePoint POCO output model object list for the CurvePoint Id in parameter. </summary>  
        /// <remarks>Status code 500 in case of exception.</remarks>
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

        /// <summary>CurvePoint controller AddCurvePoint method. 
        /// Call CurvePoint service, then CurvePoint repertory for create. 
        /// Returns CurvePoint POCO output model object created for view. </summary>  
        /// <remarks>Status code 500 in case of exception.</remarks>
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
        /// <summary>CurvePoint controller ShowUpdateForm method. 
        /// Call CurvePoint service, then CurvePoint repertory for Get. 
        /// Returns CurvePoint POCO output model object created for update view. </summary>  
        /// <remarks>Status code 500 in case of exception.</remarks>
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
        /// <summary>CurvePoint controller UpdateCurvePoint method. 
        /// Call CurvePoint service, then CurvePoint repertory for Update following input ID in parameter. 
        /// Returns CurvePoint POCO output model objects list for view. </summary>  
        /// <remarks>Status code 500 in case of exception.</remarks>
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

        /// <summary>CurvePoint controller DeleteCurvePoint method. 
        /// Call CurvePoint service, then CurvePoint repertory for Delete following input ID in parameter. 
        /// Returns CurvePoint POCO output model object deleted for view. </summary> 
        /// <param name="id">Id of the CurvePoint to delete</param>
        /// <remarks>Status code 500 in case of exception.</remarks>
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