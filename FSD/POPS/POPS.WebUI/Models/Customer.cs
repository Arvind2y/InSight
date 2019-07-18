using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POPS.WebUI.Models
{
    public class Customer
    {
        
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime Dob { get; set; }
        public Decimal Salary { get; set; }
    }

    public class CustomerContext
    {
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            return customers;
        }

        public Customer GetCustomerById(int custId = 0)
        {
            Customer customer = new Customer();

            return customer;
        }

        public int InsertCustomer(Customer customer)
        {
            int custId = 0;
            return custId;
        }

        public int UpdateCustomer(Customer customer)
        {
            return 0;
        }

        public int DeleteCustomer(int custId)
        {

            return 0;
        }
    }
}