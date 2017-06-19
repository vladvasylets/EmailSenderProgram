using EmailSenderProgram.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmailSenderProgram.Repository
{  
    public class UserRepository: IUserRepository
    {
        /// <summary>
        ///  Returns list of customers who were registered one day back in time
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> GetNewlyRegisteredCustomers()
        {
            var customers = DataLayer.ListCustomers().Where(c => c.CreatedDateTime > DateTime.Now.AddDays(-1));

            return customers;
        }

        /// <summary>
        /// Return list of customers who hasn't put an order
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> GetCustomersWithoutOrder()
        {
            var orders = DataLayer.ListOrders();
            var customers = DataLayer.ListCustomers().Where(c => !orders.Any(o => c.Email == o.CustomerEmail));

            return customers;
        }
    }
}
