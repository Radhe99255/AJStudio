using AJStudio.Core.Models;
using AJStudio.Data.Context;
using AJStudio.Data.DBTables;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJStudio.Data.Repository.ContactUs
{
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly AJStudioContext _aJStudioContext;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inject the Dependancy for the DbContext to access the database
        /// </summary>
        /// <param name="aJStudioContext"></param>
        /// <param name="mapper"></param>
        public ContactUsRepository(AJStudioContext aJStudioContext, IMapper mapper)
        {
            _aJStudioContext = aJStudioContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Get the list of all Customers from the database
        /// </summary>
        /// <returns></returns>
        public async Task<List<ContactUsModel>> Repo_GetAllContacts()
        {
            var contacts = await _aJStudioContext.ContactUsTable.ToListAsync();
            return _mapper.Map<List<ContactUsModel>>(contacts);
        }

        /// <summary>
        /// Get the customer by customer Id from the database
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<ContactUsModel> Repo_GetContactById(long contactId)
        {
            var contact = await _aJStudioContext.ContactUsTable.FirstOrDefaultAsync(x => x.Customer_Id == contactId);
            return _mapper.Map<ContactUsModel>(contact); 
        }

        /// <summary>
        /// Add Customer into the database
        /// </summary>
        /// <param name="contactUsDBTable"></param>
        /// <returns></returns>
        public async Task<string> Repo_AddContact(ContactUsModel contactUsModel)
        {
            ContactUsDBTable contactUsDBTable = new ContactUsDBTable()
            {
                First_Name = contactUsModel.First_Name,
                Last_Name = contactUsModel.Last_Name,
                Mobile_Number = contactUsModel.Mobile_Number,
                Email = contactUsModel.Email,
                State = contactUsModel.State,
                City = contactUsModel.City,
                Customer_Selected_Plane = contactUsModel.Customer_Selected_Plane,
                Suggested = contactUsModel.Suggested,
                Address = contactUsModel.Address,
                Customer_Comment = contactUsModel.Customer_Comment
            };

            await _aJStudioContext.ContactUsTable.AddAsync(contactUsDBTable);
            await _aJStudioContext.SaveChangesAsync();

            return contactUsDBTable.Customer_Id.ToString();
        }

        /// <summary>
        /// Update the customer into the database
        /// </summary>
        /// <param name="contactUsModel"></param>
        /// <returns></returns>
        public async Task<long> Repo_UpdateContact(ContactUsModel contactUsModel)
        {
            var existingContact = await _aJStudioContext.ContactUsTable.Where(x => x.Customer_Id == contactUsModel.Customer_Id).SingleOrDefaultAsync();

            if(existingContact == null)
            {
                return 0;
            }

            _aJStudioContext.Entry(existingContact).CurrentValues.SetValues(contactUsModel);
            await _aJStudioContext.SaveChangesAsync();

            return contactUsModel.Customer_Id;
        }

        /// <summary>
        /// Delete contact from the database
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public async Task<int> Repo_DeleteContact(long contactId)
        {
            var contact = await _aJStudioContext.ContactUsTable.FindAsync(contactId);

            if(contact == null)
            {
                return 0;
            }

            _aJStudioContext.ContactUsTable.Remove(contact);
            return await _aJStudioContext.SaveChangesAsync(); 
        }

        /// <summary>
        /// check the Email into the database while Add the Customer
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<bool> Repo_CheckEmail(string email)
        {
            if(email != null)
            {
                var isEmailAddExist = await _aJStudioContext.ContactUsTable.Where(x => x.Email == email).FirstOrDefaultAsync();
             
                if(isEmailAddExist != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Check email into the database while update the database
        /// Overrieded method of Add
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<bool> Repo_CheckEmail(long? contactId, string email)
        {
            if(contactId != null && email != null)
            {
                var isEmailUpdateExist = await _aJStudioContext.ContactUsTable.Where(x => x.Customer_Id != contactId && x.Email == email).FirstOrDefaultAsync();

                if(isEmailUpdateExist != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
    }
}
