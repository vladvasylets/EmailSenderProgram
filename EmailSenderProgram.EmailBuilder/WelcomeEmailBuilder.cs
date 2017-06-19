namespace EmailSenderProgram.EmailBuilder
{
    public class WelcomeEmailBuilder : BaseEmailBuilder
    {
        public WelcomeEmailBuilder() : base("Welcome as a new customer at CDON!")
        {
        }

        public override string Body
        {
            get
            {
                var template = EmailTemplates.WelcomeTemplate;

                return template;
            }
        }
    }
}
