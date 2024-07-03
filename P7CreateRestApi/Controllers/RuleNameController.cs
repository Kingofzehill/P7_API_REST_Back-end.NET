// FIX01 Add using reference Dot.Net.WebApi.Domain to RuleName Controller.
// for resolving unfound assembly reference RuleName POCO Model
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Services;

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
        /// <summary>Rule controller List method. 
        /// Call Rule service, then Rule repertory,  
        /// get Rule POCO output model object list. </summary>  
        /// <remarks>Status code 500 in case of exception.</remarks>
        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {            
            try
            {
                return Ok(_ruleNameService.List());
            }
            catch (Exception ex)
            {                
                return StatusCode(500, "Une erreur interne s'est produite");
            }
        }
        /// <summary>Rule controller Get method. 
        /// Call Rule service, then Rule repertory, 
        /// get Rule POCO output model object list for the Rule Id in parameter. </summary>  
        /// <remarks>Status code 500 in case of exception.</remarks>
        [HttpGet]
        [Route("get/{id}")]        
        public IActionResult Get([FromRoute] int id)
        {            
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
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }
        /// <summary>Rule controller AddRuleName method. 
        /// Call Rule service, then Rating repertory for create. 
        /// Returns Rule POCO output model object created for view. </summary>  
        /// <remarks>Status code 500 in case of exception.</remarks>
        [HttpPost]
        [Route("add")]
        public IActionResult AddRuleName([FromBody] RuleNameInputModel inputModel)
        {           
            try
            {
                return Ok(_ruleNameService.Create(inputModel));
            }
            catch (Exception ex)
            {                
                return StatusCode(500, "Une erreur interne s'est produite");
            }
        }
        /// <summary>Rule controller ShowUpdateForm method. 
        /// Call Rule service, then Rule repertory for Get. 
        /// Returns Rule POCO output model object created for update view. </summary>  
        /// <remarks>Status code 500 in case of exception.</remarks>
        [HttpGet]
        [Route("update/{id}")]
        public IActionResult ShowUpdateForm(int id)
        {            
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
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }
        /// <summary>Rule controller UpdateRuleName method. 
        /// Call Rule service, then Rule repertory for Update following input ID in parameter. 
        /// Returns Rule POCO output model objects list for view. </summary>  
        /// <remarks>Status code 500 in case of exception.</remarks>
        [HttpPost]
        [Route("update/{id}")]
        public IActionResult UpdateRuleName([FromRoute] int id, [FromBody] RuleNameInputModel inputModel)
        {            
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
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }
        /// <summary>Rule controller DeleteRuleName method. 
        /// Call Rule service, then Rule repertory for Delete following input ID in parameter. 
        /// Returns Rule POCO output model object deleted for view. </summary>  
        /// <param name="id">Id of the Rule to delete</param>
        /// <remarks>Status code 500 in case of exception.</remarks>
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteRuleName([FromRoute] int id)
        {            
            try
            {
                var ruleName = _ruleNameService.Delete(id);
                if (ruleName is not null)
                {
                    return Ok(_ruleNameService.List());
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