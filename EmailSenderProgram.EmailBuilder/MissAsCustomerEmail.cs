namespace EmailSenderProgram.EmailBuilder
{
    public class MissAsCustomerEmail : BaseEmailBuilder
    {
        private string _vaucher;

        public MissAsCustomerEmail(string vaucher) : base("We miss you as a customer")
        {
            this._vaucher = vaucher;
        }

        public override string Body
        {
            get
            {
                var template = EmailTemplates.MissYouAsCustomerTemplate.Replace("{Vaucher}", this._vaucher);

                return template;
            }
        }
    }
}
