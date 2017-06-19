using System;
using System.Net.Mail;
using EmailSenderProgram.EmailBuilder;

namespace EmailSenderProgram.Sender
{
    public class EmailSender
    {
        /// <summary>
        /// Sends email
        /// </summary>
        /// <param name="email"></param>
        /// <param name="emailBuilder"></param>
        public static void SendEmail(string email, BaseEmailBuilder emailBuilder)
        {
            MailMessage message = new MailMessage();
            //Add customer to reciever list
            message.To.Add(email);
            //Add subject
            message.Subject = emailBuilder.Subject;
            //Send mail from info@cdon.com
            message.From = new MailAddress(AppSettings.Sender);
            //Add body to mail
            message.Body = emailBuilder.Body.Replace("{Email}", email);
#if DEBUG
            //Don't send mails in debug mode, just write the emails in console
            Console.WriteLine("Send mail to:" + email);
#else
            //Create a SmtpClient to our smtphost: yoursmtphost
            var smtp = new SmtpClient(AppSettings.SmtpHost);
					//Send mail
					smtp.Send(message);
#endif
        }
    }
}
