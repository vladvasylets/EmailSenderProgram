using EmailSenderProgram.Data;
using EmailSenderProgram.EmailBuilder;
using EmailSenderProgram.Sender;
using System;
using System.Collections.Generic;

namespace EmailSenderProgram.Worker
{
    /// <summary>
    /// Email worker
    /// </summary>
    public class EmailWorkerFacade
    {
        BaseEmailBuilder _emailBuilder;
        IEnumerable<Customer> _customers;

        public EmailWorkerFacade(IEnumerable<Customer> customers, BaseEmailBuilder emailBuilder)
        {
            this._emailBuilder = emailBuilder;
            this._customers = customers;
        }

        public bool DoEmailWork()
        {
            try
            {
                foreach (var customer in this._customers)
                {
                    EmailSender.SendEmail(customer.Email, this._emailBuilder);
                }

                return true;
            }
            catch (Exception ex)
            {
                //Something went wrong :(
                return false;
            }
        }
    }
}
