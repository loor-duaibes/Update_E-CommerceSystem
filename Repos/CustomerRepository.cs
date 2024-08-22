using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer.DataModel;

namespace Data_Layer.Repos
{
    public class CustomerRepository
    {
        private readonly List<Customer> customers;

        public CustomerRepository()
        {
            this.customers = new List<Customer>();
        }
        public void AddCustomer(Customer customer)
        {
            if(customer == null)
            {  throw new ArgumentNullException(nameof(customer),"Customer is null"); }
            this.customers.Add(customer);
            
        }
    }
}
