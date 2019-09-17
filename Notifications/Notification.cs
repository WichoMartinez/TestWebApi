using StoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace StoreApi.Notifications
{
    public class Notification
    {

        public Notification()
        { }

        public bool SendEmail(List<Account> accounts)
        {
            MailMessage mailMessage;
            foreach (var account in accounts)
            {
                mailMessage = new MailMessage("FromEmail@.com", account.Email, "Test", "Test Api");

                var smtpClient = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("youEmail@gmail.com", "yourPassword")
                };
                smtpClient.Send(mailMessage);
            }
            return true;
        }

    }
}
