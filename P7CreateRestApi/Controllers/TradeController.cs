using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Services;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TradeController : ControllerBase
    {
        private readonly ITradeService _tradeService;
        public TradeController(ITradeService tradeService)
        {
            _tradeService = tradeService;
        }

        /// <summary>Trade controller List method. 
        /// Call Trade service, then Trade repertory,  
        /// get Trade POCO output model object list. </summary>  
        /// <remarks>Status code 500 in case of exception.</remarks>
        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {            
            try
            {
                return Ok(_tradeService.List());
            }
            catch (Exception ex)
            {                
                return StatusCode(500, "Une erreur interne s'est produite");
            }
        }

        /// <summary>Trade controller Get method. 
        /// Call Trade service, then Trade repertory, 
        /// get Trade POCO output model object list for the Trade Id in parameter. </summary>  
        /// <remarks>Status code 500 in case of exception.</remarks>
        [HttpGet]
        [Route("get/{id}")]
        public IActionResult Get([FromRoute] int id)
        {            
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
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }
        /// <summary>Trade controller AddTrade method. 
        /// Call Trade service, then Trade repertory for create. 
        /// Returns Trade POCO output model object created for view. </summary>  
        /// <remarks>Status code 500 in case of exception.</remarks>
        [HttpPost]
        [Route("add")]
        public IActionResult AddTrade([FromBody] TradeInputModel inputModel)
        {            
            try
            {
                return Ok(_tradeService.Create(inputModel));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Une erreur interne s'est produite");
            }
        }

        /// <summary>Trade controller ShowUpdateForm method. 
        /// Call Trade service, then Trade repertory for Get. 
        /// Returns Trade POCO output model object created for update view. </summary>  
        /// <remarks>Status code 500 in case of exception.</remarks>
        [HttpGet]
        [Route("update/{id}")]
        public IActionResult ShowUpdateForm(int id)
        {            
            try
            {
                var ruleName = _tradeService.Get(id);
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
        /// <summary>Trade controller UpdateTrade method. 
        /// Call Trade service, then Trade repertory for Update following input ID in parameter. 
        /// Returns Trade POCO output model objects list for view. </summary>  
        /// <remarks>Status code 500 in case of exception.</remarks>
        [HttpPost]
        [Route("update/{id}")]
        public IActionResult UpdateTrade([FromRoute] int id, [FromBody] TradeInputModel inputModel)
        {            
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
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }
        /// <summary>Trade controller DeleteTrade method. 
        /// Call Trade service, then Trade repertory for Delete following input ID in parameter. 
        /// Returns Trade POCO output model object deleted for view. </summary>  
        /// <param name="id">Id of the Trade to delete</param>
        /// <remarks>Status code 500 in case of exception.</remarks>
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteTrade([FromRoute] int id)
        {
            try
            {
                var trade = _tradeService.Delete(id);
                if (trade is not null)
                {
                    return Ok(_tradeService.List());
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