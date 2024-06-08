using AJStudio.Business.ContactUs;
using AJStudio.Business.PlaneVariety;
using AJStudio.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AJStudio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaneVarietyController : ControllerBase
    {
        private readonly IPlaneVarietyManager _planeVarietyManager;

        /// <summary>
        /// Inject the Dependancy for the Manager to access the Manager
        /// </summary>
        /// <param name="planeVarietyManager"></param>
        public PlaneVarietyController(IPlaneVarietyManager planeVarietyManager)
        {
            _planeVarietyManager = planeVarietyManager;
        }

        /// <summary>
        /// Get the list of plane vereity from Manager
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllPlaneVereitys()
        {
            return Ok(await _planeVarietyManager.Manager_GetAllPlaneVereitys());
        }

        /// <summary>
        /// Get the plane vereity detail by plane vereity Id from the Manager
        /// </summary>
        /// <param name="planeVereityId"></param>
        /// <returns></returns>
        [HttpGet("{planeVereityId}")]
        public async Task<IActionResult> PlaneVereityById([FromRoute] long planeVereityId)
        {
            var planeVereity = await _planeVarietyManager.Manager_PlaneVereityById(planeVereityId);

            if (planeVereity == null)
            {
                return NotFound();
            }

            return Ok(planeVereity);
        }

        /// <summary>
        /// Add the plane vereity into the Manager
        /// </summary>
        /// <param name="planeVarietyModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddPlaneVereity(PlaneVarietyModel planeVarietyModel)
        {
            return Ok(await _planeVarietyManager.Manager_AddPlaneVereity(planeVarietyModel));
        }

        /// <summary>
        /// Update the plane vereity into the Manager
        /// </summary>
        /// <param name="planeVereityId"></param>
        /// <param name="planeVarietyModel"></param>
        /// <returns></returns>
        [HttpPut("{planeVereityId}")]
        public async Task<IActionResult> UpdatePlaneVereity([FromRoute] long planeVereityId, [FromBody] PlaneVarietyModel planeVarietyModel)
        {
            if (planeVereityId != planeVarietyModel.PlaneVariety_Id)
            {
                return BadRequest();
            }

            return Ok(await _planeVarietyManager.Manager_UpdatePlaneVereity(planeVarietyModel));
        }

        /// <summary>
        /// Delete plane vereity from the Manager
        /// </summary>
        /// <param name="planeVereityId"></param>
        /// <returns></returns>
        [HttpDelete("{planeVereityId}")]
        public async Task<IActionResult> DeleteContact([FromRoute] long planeVereityId)
        {
            return Ok(await _planeVarietyManager.Manager_DeletePlaneVereity(planeVereityId));
        }
    }
}
