using AJStudio.Business.EmailServices;
using AJStudio.Core.Models;
using AJStudio.Data.DBTables;
using AJStudio.Data.Repository.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJStudio.Business.ContactUs
{
    public class ContactUsManager : IContactUsManager
    {
        private readonly IContactUsRepository _contactUsRepository;
        private readonly IEmailSender _emailSender;

        /// <summary>
        /// Inject the Dependancy for the Repository to access the Repository
        /// </summary>
        /// <param name="contactUsRepository"></param>
        public ContactUsManager(IContactUsRepository contactUsRepository, IEmailSender emailSender)
        {
            _contactUsRepository = contactUsRepository;
            _emailSender = emailSender;
        }

        /// <summary>
        /// Get the list of customers from the repository
        /// </summary>
        /// <returns></returns>
        public async Task<List<ContactUsModel>> Manager_GetAllContacts()
        {
            return await _contactUsRepository.Repo_GetAllContacts();
        }

        /// <summary>
        /// Get the customer by customer id from the repository
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<ContactUsModel> Manager_GetContactById(long contactId)
        {
            return await _contactUsRepository.Repo_GetContactById(contactId);
        }

        /// <summary>
        /// Add the customer into the repository with validation of Email
        /// </summary>
        /// <param name="contactUsModel"></param>
        /// <returns></returns>
        public async Task<string> Manager_AddContact(ContactUsModel contactUsModel)
        {
            var checkEmail = await _contactUsRepository.Repo_CheckEmail(contactUsModel.Email);

            if (checkEmail)
            {
                return "Exist";
            }

            return await _contactUsRepository.Repo_AddContact(contactUsModel);
        }

        /// <summary>
        /// Update Customer into the Repository
        /// </summary>
        /// <param name="contactUsModel"></param>
        /// <returns></returns>
        public async Task<string> Manager_UpdateContact(ContactUsModel contactUsModel)
        {
            var checkEmailWithId = await _contactUsRepository.Repo_CheckEmail(contactUsModel.Customer_Id, contactUsModel.Email);

            if (checkEmailWithId)
            {
                return "Exist";
            }

            var updateContact = await _contactUsRepository.Repo_UpdateContact(contactUsModel);

            if (updateContact > 0)
            {
                return "Success";
            }

            return "Fail";
        }

        /// <summary>
        /// Delete Customer from the repository
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public async Task<string> Manager_DeleteContact(long contactId)
        {
            var deleteResult = await _contactUsRepository.Repo_DeleteContact(contactId);

            if (deleteResult > 0)
            {
                return "Success";
            }

            return "Fail";
        }


        //* Email Sender Section
        // I have saperatly handle the email service beacouse it may take time to send the email 
        // for that after registration completed i am sending the email from frontend
        // means after registration success  i am making anither api call for saperatly for the email sending

        /// <summary>
        /// Send Email to new Registered customer
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="newUserEmail"></param>
        /// <returns></returns>
        public async Task<string> NewCustomerRegistrationMail(long contactId, string newUserEmail)
        {
            var newUserContact = await _contactUsRepository.Repo_GetContactById(contactId);

            var msgBody = CustomerMessageBody(newUserContact);

            var receiverEmail = newUserEmail;
            var subject = "Thank You for Connecting AJstudio!";
            var message = msgBody;

            await _emailSender.SendEmailAsync(receiverEmail, subject, message);

            var aakash_Smit_MsgBody = Aaskah_Smit_EmailMassageBody(newUserContact);

            var receiverEmail_Aakash = "akashhapani838@gmail.com";
            var receiverEmail_Smit = "smitvaddoriya123@gmail.com";
            var ownerSubject = $"New Inquiry from {newUserContact.First_Name} {newUserContact.Last_Name}";
            var ownerMsgBody = aakash_Smit_MsgBody;

            await _emailSender.SendEmailAsync("patelpassport1234@gmail.com", ownerSubject, ownerMsgBody);
            await _emailSender.SendEmailAsync(receiverEmail_Aakash, ownerSubject, ownerMsgBody);
            await _emailSender.SendEmailAsync(receiverEmail_Smit, ownerSubject, ownerMsgBody);

            return $"Success";
        }

        /// <summary>
        /// Set the Email Massage Body for the cutomer
        /// </summary>
        /// <param name="customerContact"></param>
        /// <returns></returns>
        private string CustomerMessageBody(ContactUsModel customerContact)
        {
            var msgBody = $@"
                <div style=""width: 100%; max-width: 600px; margin: 20px auto; background-color: #ffffff; border: 1px solid #e0e0e0; border-radius: 8px; overflow: hidden;"">
                    <div style=""background-color: #0073e6; color: #ffffff; padding: 20px; text-align: center;"">
                        <h1>Thank You for Connecting AJstudio!</h1>
                    </div>
                    <div style=""padding: 20px;"">
                        <p>Dear {customerContact.First_Name} {customerContact.Last_Name},</p>
                        <p>Thank you for reaching out to AJstudio. We have received your inquiry and will get back to you shortly. Below is a summary of the information you provided:</p>
                
                        <div style=""font-size: 1.2em; margin-top: 20px; margin-bottom: 10px; color: #0073e6;"">Customer Information:</div>
                        <table style=""width: 100%; border-collapse: collapse; margin-bottom: 20px;"">
                            <tr>
                                <th style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left; background-color: #f9f9f9;"">Customer ID</th>
                                <td style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left;"">{customerContact.Customer_Id}</td>
                            </tr>
                            <tr>
                                <th style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left; background-color: #f9f9f9;"">Full Name</th>
                                <td style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left;"">{customerContact.First_Name} {customerContact.Last_Name}</td>
                            </tr>
                            <tr>
                                <th style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left; background-color: #f9f9f9;"">Mobile Number</th>
                                <td style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left;"">{customerContact.Mobile_Number}</td>
                            </tr>
                            <tr>
                                <th style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left; background-color: #f9f9f9;"">Email</th>
                                <td style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left;"">{customerContact.Email}</td>
                            </tr>
                            <tr>
                                <th style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left; background-color: #f9f9f9;"">State</th>
                                <td style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left;"">{customerContact.State}</td>
                            </tr>
                            <tr>
                                <th style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left; background-color: #f9f9f9;"">City</th>
                                <td style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left;"">{customerContact.City}</td>
                            </tr>
                            <tr>
                                <th style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left; background-color: #f9f9f9;"">Address</th>
                                <td style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left;"">{customerContact.Address}</td>
                            </tr>
                        </table>

                        <div style=""font-size: 1.2em; margin-top: 20px; margin-bottom: 10px; color: #0073e6;"">Event Details:</div>
                        <table style=""width: 100%; border-collapse: collapse; margin-bottom: 20px;"">
                            <tr>
                                <th style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left; background-color: #f9f9f9;"">Selected Plan</th>
                                <td style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left;"">{customerContact.Customer_Selected_Plane}</td>
                            </tr>
                            <tr>
                                <th style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left; background-color: #f9f9f9;"">How You Heard About Us</th>
                                <td style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left;"">{customerContact.Suggested}</td>
                            </tr>
                            <tr>
                                <th style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left; background-color: #f9f9f9;"">Additional Comments</th>
                                <td style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left;"">{customerContact.Customer_Comment}</td>
                            </tr>
                        </table>

                        <p>We appreciate your interest in AJstudio and look forward to helping you make your event special. If you have any immediate questions or need further assistance, please feel free to contact us at +916355726753.</p>
    
                        <p>Best Regards,</p>
                        <p><strong>The AJstudio Team</strong></p>
                    </div>
                    <div style=""background-color: #f1f1f1; color: #666666; padding: 20px; text-align: center; font-size: 0.9em;"">
                        Surat<br>
                        +916355726753<br>
                        ajstudio838@gmail.com<br>
                        <a href=""#"" style=""color: #0073e6;"">AJStudio.com</a>
                    </div>
                </div>
                ";

            return msgBody;
        }

        /// <summary>
        /// Set the Email message body for the Smit & aakash
        /// </summary>
        /// <param name="customerContact"></param>
        /// <returns></returns>
        private string Aaskah_Smit_EmailMassageBody(ContactUsModel customerContact)
        {
            var msgBody = $@"
                <div style=""width: 100%; max-width: 600px; margin: 20px auto; background-color: #ffffff; border: 1px solid #e0e0e0; border-radius: 8px; overflow: hidden;"">
                    <div style=""background-color: #0073e6; color: #ffffff; padding: 20px; text-align: center;"">
                        <h1>New Inquiry from {customerContact.First_Name} {customerContact.Last_Name}</h1>
                    </div>
                    <div style=""padding: 20px;"">
                        <p>Hello AJstudio Team,</p>
                        <p>You have received a new inquiry from a potential customer. Below are the details:</p>
                
                        <div style=""font-size: 1.2em; margin-top: 20px; margin-bottom: 10px; color: #0073e6;"">Customer Information:</div>
                        <table style=""width: 100%; border-collapse: collapse; margin-bottom: 20px;"">
                            <tr>
                                <th style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left; background-color: #f9f9f9;"">Customer ID</th>
                                <td style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left;"">{customerContact.Customer_Id}</td>
                            </tr>
                            <tr>
                                <th style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left; background-color: #f9f9f9;"">Full Name</th>
                                <td style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left;"">{customerContact.First_Name} {customerContact.Last_Name}</td>
                            </tr>
                            <tr>
                                <th style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left; background-color: #f9f9f9;"">Mobile Number</th>
                                <td style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left;"">{customerContact.Mobile_Number}</td>
                            </tr>
                            <tr>
                                <th style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left; background-color: #f9f9f9;"">Email</th>
                                <td style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left;"">{customerContact.Email}</td>
                            </tr>
                            <tr>
                                <th style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left; background-color: #f9f9f9;"">State</th>
                                <td style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left;"">{customerContact.State}</td>
                            </tr>
                            <tr>
                                <th style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left; background-color: #f9f9f9;"">City</th>
                                <td style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left;"">{customerContact.City}</td>
                            </tr>
                            <tr>
                                <th style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left; background-color: #f9f9f9;"">Address</th>
                                <td style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left;"">{customerContact.Address}</td>
                            </tr>
                        </table>

                        <div style=""font-size: 1.2em; margin-top: 20px; margin-bottom: 10px; color: #0073e6;"">Event Details:</div>
                        <table style=""width: 100%; border-collapse: collapse; margin-bottom: 20px;"">
                            <tr>
                                <th style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left; background-color: #f9f9f9;"">Selected Plan</th>
                                <td style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left;"">{customerContact.Customer_Selected_Plane}</td>
                            </tr>
                            <tr>
                                <th style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left; background-color: #f9f9f9;"">How You Heard About Us</th>
                                <td style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left;"">{customerContact.Suggested}</td>
                            </tr>
                            <tr>
                                <th style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left; background-color: #f9f9f9;"">Additional Comments</th>
                                <td style=""border: 1px solid #e0e0e0; padding: 10px; text-align: left;"">{customerContact.Customer_Comment}</td>
                            </tr>
                        </table>

                        <p>Please follow up with the customer as soon as possible to assist with their inquiry and plan their event.</p>
    
                        <p>Best Regards,</p>
                        <p><strong>AJstudio Notification System</strong></p>
                    </div>
                    <div style=""background-color: #f1f1f1; color: #666666; padding: 20px; text-align: center; font-size: 0.9em;"">
                        Surat<br>
                        +916355726753<br>
                        ajstudio838@gmail.com<br>
                        <a href=""#"" style=""color: #0073e6;"">AJStudio.com</a>
                    </div>
                </div>
                ";

            return msgBody;
        }
        
    }
}
