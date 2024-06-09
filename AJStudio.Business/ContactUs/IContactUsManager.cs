using AJStudio.Core.Enum;
using AJStudio.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJStudio.Business.ContactUs
{
    public interface IContactUsManager
    {
        Task<List<ContactUsModel>> Manager_GetAllContacts();
        Task<ContactUsModel> Manager_GetContactById(long contactId);
        Task<CustomerAddResponceModel> Manager_AddContact(ContactUsModel contactUsModel);
		Task<string> Manager_UpdateContact(ContactUsModel contactUsModel);
        Task<string> Manager_DeleteContact(long contactId);
		Task<string> NewCustomerRegistrationMail(long contactId);

	}
}
