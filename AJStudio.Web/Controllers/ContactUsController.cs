using AJStudio.Core.Enum;
using AJStudio.Core.Models;
using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AJStudio.Web.Controllers
{
	public class ContactUsController : Controller
	{
		private readonly IConfiguration _configuration;
		private readonly string? _contactUsApiUrl;

        public ContactUsController(IConfiguration configuration)
        {
            _configuration = configuration;
			_contactUsApiUrl = _configuration["ApiUrl:ContactUs_ApiUrl"];
        }


        [HttpPost]
		public async Task<IActionResult> SubmitCustomerData(ContactUsModel contactUsModel)
		{
			try
			{
				var apiContactUsResponce = await _contactUsApiUrl.PostJsonAsync(contactUsModel);
				
				var responseContent = await apiContactUsResponce.ResponseMessage.Content.ReadAsStringAsync();

				var customerAddResponse = JsonConvert.DeserializeObject<CustomerAddResponceModel>(responseContent);

				return Json(customerAddResponse);
			}
			catch (Exception ex)
			{
				return RedirectToAction("ContactUs", "Home");
			}
		}

		[HttpPost]
		public async Task<IActionResult> SendEmail(CustomerAddResponceModel customerAddResponceModel)
		{
			try
			{
				var apiContactUsResponce = await _contactUsApiUrl
					.AppendPathSegment("newCustomerRegistrationEmail")
					.PostJsonAsync(customerAddResponceModel);

				if(apiContactUsResponce.StatusCode == 200)
				{
					return Json("Success");
				}

				return Json("");
			}
			catch(Exception ex)
			{
				return RedirectToAction("ContactUs", "Home");
			}
		}
	}
}
