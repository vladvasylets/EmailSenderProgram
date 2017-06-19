using EmailSenderProgram.EmailBuilder;
using EmailSenderProgram.Repository;
using System;
using System.Linq;

namespace EmailSenderProgram.Worker
{
    /// <summary>
    /// Defines method for creating email sender facade 
    /// </summary>
    public class EmailWorkerFactory
    {
        /// <summary>
        /// Returns email worker within template and list of customers by email type 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static EmailWorkerFacade GetWorker(EmailType type)
        {
            IUserRepository userRepository = new UserRepository();

            switch (type)
            {
                case EmailType.WelcomeEmail:
                    {
                        var customers = userRepository.GetNewlyRegisteredCustomers();
                        BaseEmailBuilder emailBuilder = new WelcomeEmailBuilder();

                        return new EmailWorkerFacade(customers, emailBuilder);
                    }
                case EmailType.MissAsCustomerEmail:
                    {
                        var customers = userRepository.GetCustomersWithoutOrder();
                        const string vaucher = "CDONComebackToUs";
                        BaseEmailBuilder emailBuilder = new MissAsCustomerEmail(vaucher);

                        return new EmailWorkerFacade(customers, emailBuilder);
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
