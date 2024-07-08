using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>[HttpGet] Trade controller List method. 
        /// Call Trade service, then Trade repertory and 
        /// get Trade list. </summary>  
        /// <returns>Status code 200 (OK) with Trade list 
        /// OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpGet]
        [Route("list")]
        [Authorize(policy: "User")]
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

        /// <summary>[HttpGet] Trade controller Get method. 
        /// Call Trade service, then Trade repertory and get Trade
        /// corresponding to Id in input parameter.</summary>  
        /// <param name="id">Id of the Trade to get.</param>
        /// <returns>Status code 200 (OK) with Trade selected
        /// OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpGet]
        [Route("get/{id}")]
        [Authorize(policy: "User")]
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
        /// <summary>[HttpPost] Trade controller AddTrade method. 
        /// Call Trade service, then Trade repertory and create Trade.</summary>  
        /// <param name="inputModel">POCO Trade input model class object.</param>
        /// <returns>Status code 200 (OK) with user created
        /// OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpPost]
        [Route("add")]
        [Authorize(policy: "User")]
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

        /// <summary>[HttpGet] Trade controller ShowUpdateForm method. 
        /// Call Trade service, then Trade repertory and get Trade.</summary>  
        /// <param name="id">Id of the Trade.</param>
        /// <returns>Status code 200 (OK) with selected Trade 
        /// OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpGet]
        [Route("update/{id}")]
        [Authorize(policy: "User")]
        public IActionResult ShowUpdateForm(int id)
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
        /// <summary>[HttpPost] Trade controller UpdateTrade method. 
        /// Call Trade service, then Trade repertory and update Trade 
        /// corresponding to Id in input parameter</summary>   
        /// <param name="id">Id of the Trade to update.</param>
        /// <param name="inputModel">POCO Trade input model class object.</param>
        /// <returns>Status code 200 (OK) with updated Trade list 
        /// OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpPost]
        [Route("update/{id}")]
        [Authorize(policy: "User")]
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
        /// <summary>[HttpDelete] Trade controller DeleteTrade method. 
        /// Call Trade service, then Trade repertory and 
        /// delete Trade corresponding to Id in input parameter.</summary> 
        /// <param name="id">Id of the Trade to delete</param>
        /// <returns>Status code 200 (OK) with remaining Trade list 
        /// OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpDelete]
        [Route("delete/{id}")]
        [Authorize(policy: "User")]
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