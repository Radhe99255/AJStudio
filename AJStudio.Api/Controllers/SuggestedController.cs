using AJStudio.Business.ContactUs;
using AJStudio.Business.Suggested;
using AJStudio.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AJStudio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuggestedController : ControllerBase
    {
        private readonly ISuggestedManager _suggestedManager;

        /// <summary>
        /// Inject the Dependancy for the Manager to access the Manager
        /// </summary>
        /// <param name="suggestedManager"></param>
        public SuggestedController(ISuggestedManager suggestedManager)
        {
            _suggestedManager = suggestedManager;
        }

        /// <summary>
        /// Get the list of suggested from Manager
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllSuggested()
        {
            return Ok(await _suggestedManager.Manager_GetAllSuggested());
        }

        /// <summary>
        /// Get the suggested detail by suggested Id from the Manager
        /// </summary>
        /// <param name="suggestedId"></param>
        /// <returns></returns>
        [HttpGet("{suggestedId}")]
        public async Task<IActionResult> GetSuggestedById([FromRoute] long suggestedId)
        {
            var suggested = await _suggestedManager.Manager_GetSuggestedById(suggestedId);

            if (suggested == null)
            {
                return NotFound();
            }

            return Ok(suggested);
        }

        /// <summary>
        /// Add the suggested into the Manager
        /// </summary>
        /// <param name="suggestedModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddSuggested([FromBody] SuggestedModel suggestedModel)
        {
            return Ok(await _suggestedManager.Manager_AddSuggested(suggestedModel));
        }

        /// <summary>
        /// Update the suggested into the Manager
        /// </summary>
        /// <param name="suggestedId"></param>
        /// <param name="suggestedModel"></param>
        /// <returns></returns>
        [HttpPut("{suggestedId}")]
        public async Task<IActionResult> UpdateSuggested([FromRoute] long suggestedId, [FromBody] SuggestedModel suggestedModel)
        {
            if (suggestedId != suggestedModel.Suggested_Id)
            {
                return BadRequest();
            }

            return Ok(await _suggestedManager.Manager_UpdateSuggested(suggestedModel));
        }

        /// <summary>
        /// Delete suggested from the Manager
        /// </summary>
        /// <param name="suggestedId"></param>
        /// <returns></returns>
        [HttpDelete("{suggestedId}")]
        public async Task<IActionResult> DeleteSuggested([FromRoute] long suggestedId)
        {
            return Ok(await _suggestedManager.Manager_DeleteSuggested(suggestedId));
        }
    }
}
