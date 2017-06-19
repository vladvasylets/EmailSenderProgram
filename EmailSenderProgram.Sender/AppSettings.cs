using System.Configuration;

namespace EmailSenderProgram.Sender
{
    public class AppSettings
    {
        public static readonly string SmtpHost = ConfigurationManager.AppSettings["smtphost"];

        public static readonly string Sender = ConfigurationManager.AppSettings["senderemail"];
    }
}
