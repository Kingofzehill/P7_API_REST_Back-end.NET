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

        /// <summary>BidList controller List method. 
        /// Call BidList service, then BidList repertory. 
        /// Get BidList POCO output model object list. </summary>  
        /// <remarks>Status code 500 in case of exception.</remarks>
        [HttpGet]
        [Route("list")]
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

        /// <summary>BidList controller Get method. 
        /// Call BidList service, then BidList repertory. 
        /// Get BidList POCO output model object list for the BidList Id in parameter. </summary>  
        /// <remarks>Status code 500 in case of exception.</remarks>
        [HttpGet]
        [Route("get/{id}")]
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

        /// <summary>BidList controller AddBidList method. 
        /// Call BidList service, then BidList repertory for create. 
        /// Returns BidList POCO output model object created for view. </summary>  
        /// <remarks>Status code 500 in case of exception.</remarks>
        [HttpPost]
        [Route("add")]
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

        /// <summary>BidList controller ShowUpdateForm method. 
        /// Call BidList service, then BidList repertory for Get. 
        /// Returns BidList POCO output model object created for update  view. </summary>  
        /// <remarks>Status code 500 in case of exception.</remarks>
        [HttpGet]
        [Route("update/{id}")]
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

        /// <summary>BidList controller UpdateBid method. 
        /// Call BidList service, then BidList repertory for Update following input ID in parameter. 
        /// Returns BidList POCO output model objects list for view. </summary>  
        /// <remarks>Status code 500 in case of exception.</remarks>
        [HttpPost]
        [Route("update/{id}")]
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

        /// <summary>BidList controller DeleteBid method. 
        /// Call BidList service, then BidList repertory for Delete following input ID in parameter. 
        /// Returns BidList POCO output model object deleted for view. </summary>  
        /// <remarks>Status code 500 in case of exception.</remarks>
        [HttpDelete]
        [Route("{id}")]
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