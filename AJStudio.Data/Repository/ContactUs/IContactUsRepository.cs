using AJStudio.Core.Models;
using AJStudio.Data.DBTables;

namespace AJStudio.Data.Repository.ContactUs
{
    public interface IContactUsRepository
    {
        Task<List<ContactUsModel>> Repo_GetAllContacts();
        Task<ContactUsModel> Repo_GetContactById(long contactId);
        Task<string> Repo_AddContact(ContactUsModel contactUsModel);
        Task<long> Repo_UpdateContact(ContactUsModel contactUsModel);
        Task<int> Repo_DeleteContact(long contactId);
        Task<bool> Repo_CheckEmail(string email);
        Task<bool> Repo_CheckEmail(long? contactId, string email);
    }
}
