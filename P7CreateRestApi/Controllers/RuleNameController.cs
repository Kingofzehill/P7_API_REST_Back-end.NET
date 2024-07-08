// FIX01 Add using reference Dot.Net.WebApi.Domain to RuleName Controller.
// for resolving unfound assembly reference RuleName POCO Model
using Microsoft.AspNetCore.Authorization;
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
        /// <summary>[HttpGet] Rule controller List method. 
        /// Call Rule service, then Rule repertory and 
        /// get Rule list. </summary>  
        /// <returns>Status code 200 (OK) with Rule list 
        /// OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpGet]
        [Route("list")]
        [Authorize(policy: "User")]
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
        /// <summary>[HttpGet] Rule controller Get method. 
        /// Call Rule service, then Rule repertory and get Rule
        /// corresponding to Id in input parameter.</summary>  
        /// <param name="id">Id of the Rule to get.</param>
        /// <returns>Status code 200 (OK) with Rule selected
        /// OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpGet]
        [Route("get/{id}")]
        [Authorize(policy: "User")]
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
        /// <summary>[HttpPost] Rule controller AddRuleName method. 
        /// Call Rule service, then Rule repertory for create.</summary>  
        /// <param name="inputModel">POCO Rule input model class object.</param>
        /// <returns>Status code 200 (OK) with Rule created 
        /// OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpPost]
        [Route("add")]
        [Authorize(policy: "User")]
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
        /// <summary>[HttpGet] Rule controller ShowUpdateForm method. 
        /// Call Rule service, then Rule repertory and get Rule.</summary>  
        /// <param name="id">Id of the Rule.</param>
        /// <returns>Status code 200 (OK) with selected Rule 
        /// OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpGet]
        [Route("update/{id}")]
        [Authorize(policy: "User")]
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
        /// <summary>[HttpPost] Rule controller UpdateRuleName method. 
        /// Call Rule service, then Rule repertory and update Rule 
        /// corresponding to Id in input parameter</summary>   
        /// <param name="id">Id of the Rule to update.</param>
        /// <param name="inputModel">POCO Rule input model class object.</param>
        /// <returns>Status code 200 (OK) with updated Rule list 
        /// OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpPost]
        [Route("update/{id}")]
        [Authorize(policy: "User")]
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
        /// <summary>[HttpDelete] Rule controller DeleteRuleName method. 
        /// Call Rule service, then Rule repertory and 
        /// delete Rule corresponding to Id in input parameter.</summary> 
        /// <param name="id">Id of the Rule to delete</param>
        /// <returns>Status code 200 (OK) with remaining Rule list 
        /// OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpDelete]
        [Route("delete/{id}")]
        [Authorize(policy: "User")]
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