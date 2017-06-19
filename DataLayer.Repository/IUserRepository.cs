using EmailSenderProgram.Data;
using System.Collections.Generic;

namespace EmailSenderProgram.Repository
{
    public interface IUserRepository
    {
        IEnumerable<Customer> GetNewlyRegisteredCustomers();

        IEnumerable<Customer> GetCustomersWithoutOrder();
    }
}
