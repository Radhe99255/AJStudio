using AJStudio.Business.ContactUs;
using AJStudio.Core.Enum;
using AJStudio.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AJStudio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsManager _contactUsManager;

        /// <summary>
        /// Inject the Dependancy for the Manager to access the Manager
        /// </summary>
        /// <param name="contactUsManager"></param>
        public ContactUsController(IContactUsManager contactUsManager)
        {
            _contactUsManager = contactUsManager;
        }

        /// <summary>
        /// Get the list of customer from Manager
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            return Ok(await _contactUsManager.Manager_GetAllContacts());
        }

        /// <summary>
        /// Get the customer detail by customer Id from the Manager
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("{contactId}")]
        public async Task<IActionResult> GetContactById([FromRoute] long contactId)
        {
            var contact = await _contactUsManager.Manager_GetContactById(contactId);

            if(contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        /// <summary>
        /// Add the customer into the Manager
        /// </summary>
        /// <param name="contactUsModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody] ContactUsModel contactUsModel)
        {
            return Ok(await _contactUsManager.Manager_AddContact(contactUsModel));
        }

        /// <summary>
        /// Update the customer into the Manager
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="contactUsModel"></param>
        /// <returns></returns>
        [HttpPut("{contactId}")]
        public async Task<IActionResult> UpdateContact([FromRoute] long contactId , [FromBody] ContactUsModel contactUsModel)
        {
            if(contactId != contactUsModel.Customer_Id)
            {
                return BadRequest();
            }

            return Ok(await _contactUsManager.Manager_UpdateContact(contactUsModel));
        }

        /// <summary>
        /// Delete customer from the Manager
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        [HttpDelete("{contactId}")]
        public async Task<IActionResult> DeleteContact([FromRoute] long contactId)
        {
            return Ok(await _contactUsManager.Manager_DeleteContact(contactId));
        }

        /// <summary>
        /// Send Email of new Registered customer
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("newCustomerRegistrationEmail")]
        public async Task<IActionResult> NewCustomerRegistrationMail([FromBody] CustomerAddResponceModel customerAddResponceModel)
        {
            return Ok(await _contactUsManager.NewCustomerRegistrationMail(customerAddResponceModel.contactId));
        }
    }
}
