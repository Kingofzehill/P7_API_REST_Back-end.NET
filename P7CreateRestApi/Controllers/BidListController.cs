using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models.InputModels;
using P7CreateRestApi.Services;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BidListController : ControllerBase
    {
        private readonly IBidListService _bidListService;
        public BidListController(IBidListService bidListService)
        {
            _bidListService = bidListService;
        }

        /// <summary>[HttpGet] BidList controller List method. 
        /// Call BidList service, then BidList repertory, 
        /// get BidList POCO output model objects list. </summary>  
        /// <returns>Status code 200 (OK) with BidList list OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpGet]
        [Route("list")]
        [Authorize(policy: "User")]
        public IActionResult List()
        {
            try
            {
                return Ok(_bidListService.List());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Une erreur interne s'est produite");
            }
        }

        /// <summary>[HttpGet] BidList controller Get method. 
        /// Call BidList service, then BidList repertory. 
        /// Get BidList POCO output model object for the BidList Id in parameter. </summary>  
        /// <param name="id">Id of the BidList.</param>
        /// <returns>Status code 200 (OK) with BidList object selected OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpGet]
        [Route("get/{id}")]
        [Authorize(policy: "User")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                var bidList = _bidListService.Get(id);
                if (bidList is not null)
                {
                    return Ok(bidList);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }

        /// <summary>[HttpPost] BidList controller AddBidList method. 
        /// Call BidList service, then BidList repertory for create. 
        /// Returns BidList POCO output model object created for view. </summary>  
        /// <param name="inputModel">POCO BidList input model class object.</param>
        /// <returns>Status code 200 (OK) with BidList created 
        /// OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpPost]
        [Route("add")]
        [Authorize(policy: "User")]
        public IActionResult AddBidList([FromBody] BidListInputModel inputModel)
        {
            try
            {
                return Ok(_bidListService.Create(inputModel));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Une erreur interne s'est produite");
            }
        }

        /// <summary>[HttpGet] BidList controller ShowUpdateForm method. 
        /// Call BidList service, then BidList repertory for Get.</summary>  
        /// <param name="id">Id of the BidList to show.</param>
        /// <returns>Status code 200 (OK) with BidList object selected OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpGet]
        [Route("update/{id}")]
        [Authorize(policy: "User")]
        public IActionResult ShowUpdateForm(int id)
        {

            try
            {
                var bidList = _bidListService.Get(id);
                if (bidList is not null)
                {
                    return Ok(bidList);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }

        /// <summary>[HttpPost] BidList controller UpdateBid method. 
        /// Call BidList service, then BidList repertory for Update following input ID in parameter.</summary>  
        /// <param name="id">Id of the BidList to update.</param>
        /// <param name="inputModel">POCO BidList input model class object.</param>
        /// <returns>Status code 200 (OK) with updated BidList list OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpPost]
        [Route("update/{id}")]
        [Authorize(policy: "User")]
        public IActionResult UpdateBid(int id, [FromBody] BidListInputModel inputModel)
        {
            try
            {
                var bidList = _bidListService.Update(id, inputModel);
                if (bidList is not null)
                {
                    return Ok(_bidListService.List());
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }

        /// <summary>[HttpDelete] BidList controller DeleteBid method. 
        /// Call BidList service, then BidList repertory for deleting BidList 
        /// corresponding to input ID in parameter. </summary>  
        /// <param name="id">Id of the BidList to delete.</param>
        /// <returns>Status code 200 (OK) with remaining BidList list OR error code 500 if exception.</returns> 
        /// <remarks>Authenticated and authorized User access only</remarks>
        [HttpDelete]
        [Route("delete/{id}")]
        [Authorize(policy: "User")]
        public IActionResult DeleteBid(int id)
        {
            try
            {
                var bidList = _bidListService.Delete(id);
                if (bidList is not null)
                {
                    return Ok(_bidListService.List());
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