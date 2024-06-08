using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AJStudio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ApiGlobalExceptionController : ControllerBase
    {
        private readonly ILogger<ApiGlobalExceptionController> _logger;
        public ApiGlobalExceptionController(ILogger<ApiGlobalExceptionController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Global Error Handling
        /// </summary>
        /// <returns>
        /// Error occures during execution then it will handle globally
        /// </returns>
        public IActionResult Get()
        {
            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;



            _logger.LogError(exceptionHandlerFeature.Error, "Hey Error Avi gay che Developer \"Harshil Patel(Mo - 9925530740)\" no contact karo...");


            return Problem(
                //detail: exceptionHandlerFeature.Error.StackTrace, // we can change these messages also
                detail: "Error avi gay che Contact to API Developer \"Harshil Patel(Mo - 9925530740)\"",
                title: exceptionHandlerFeature.Error.Message);
        }
    }
}
