using EmailSenderProgram.Worker;
using System;

namespace EmailSenderProgram
{
    internal class Program
    {
        /// <summary>
        /// This application is run everyday
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            bool success = false;
            EmailWorkerFacade facade;
            //Call the method that do the work for me, I.E. sending the mails
            Console.WriteLine("Send Welcome email");
            facade = EmailWorkerFactory.GetWorker(EmailType.WelcomeEmail);

            if (facade != null)
            {
                success = facade.DoEmailWork();
            }

#if DEBUG
			//Debug mode, always send Comeback mail
			Console.WriteLine("Send Comebackmail");
            facade = EmailWorkerFactory.GetWorker(EmailType.MissAsCustomerEmail);
            if (facade != null)
            {
                success = facade.DoEmailWork();
            }
#else
            //Every Sunday run Comeback mail
            if (DateTime.Now.DayOfWeek.Equals(DayOfWeek.Sunday))
            {
                Console.WriteLine("Send Comebackmail");
                facade = EmailWorkerFactory.GetWorker(EmailType.MissAsCustomerEmail);
                if (facade != null)
                {
                    success = facade.DoEmailWork();
                }
            }
#endif

            //Check if the sending went OK
            Console.WriteLine(
                success
                    ? "All mails are sent, I hope..."
                    : "Oops, something went wrong when sending mail (I think...)");

            Console.ReadKey();
        }
    }
}