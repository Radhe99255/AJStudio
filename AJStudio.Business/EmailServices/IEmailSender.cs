using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJStudio.Business.EmailServices
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string receiverEmail, string subject, string message);
    }
}
