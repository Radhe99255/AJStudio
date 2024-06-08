using System.Net;
using System.Net.Mail;

namespace AJStudio.Business.EmailServices
{
    public class EmailSender : IEmailSender
    {
        //* more information : https://tutorials.eu/how-to-send-emails-in-asp-net-web-applications/
        public Task SendEmailAsync(string receiverEmail, string subject, string message)
        {

            var senderMail = "ajstudio838@gmail.com";
            var senderPassword = "thao uyah ntxv gvdd"; // i used app password here


            // here i creted smtpClient object that
            // host, port, credential for sender
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderMail, senderPassword)
            };


            var mailMessage = new MailMessage(from: senderMail, to: receiverEmail)
            {
                Subject = subject,
                Body = message,
                IsBodyHtml = true // Set IsBodyHtml to true for HTML content
            };

            return client.SendMailAsync(mailMessage);


            /*
             * this is my old that sending normal content to the body 
            return client.SendMailAsync(
                new MailMessage(from: senderMail,
                                to: receiverEmail,
                                subject,
                                message
                                ));
            */
        }
    }
}
