namespace EmailSenderProgram.EmailBuilder
{
    public abstract class BaseEmailBuilder
    {
        public string Subject { get; }

        public abstract string Body { get; }


        public BaseEmailBuilder(string subject)
        {
            this.Subject = subject;
        }
    }
}
