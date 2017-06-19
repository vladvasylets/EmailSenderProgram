namespace EmailSenderProgram
{
    /// <summary>
    /// Defines email types. If count of email types will be multiple - it can be better to store templates in html-files
    /// </summary>
    public class EmailTemplates
    {
        public const string WelcomeTemplate = @"Hi {Email}<br>We would like to welcome you as customer on our site!<br><br>Best Regards,<br>CDON Team";

        public const string MissYouAsCustomerTemplate = @"Hi {Email}
<br>We miss you as a customer. Our shop is filled with nice products. Here is a voucher that gives you 50 kr to shop for.
<br> Voucher: {Vaucher}
<br><br>Best Regards,<br>CDON Team";
    }
}
