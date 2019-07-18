using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Models
{
    public class CustomerContext
    {
        string connectionString ="Server=DESKTOP-NRTU79P;Database=CMSDb;Trusted_Connection=True; Integrated Security=True;Connect Timeout=30;";

        public IEnumerable<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllCustomers", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Customer customer = new Customer()
                    {
                        CustomerId = Convert.ToInt32(rdr["CustomerId"]),
                        Name = rdr["Name"].ToString(),
                        Address = rdr["Address"].ToString(),
                        Dob = (DateTime)rdr["Dob"],
                        Salary = (decimal)(rdr["Salary"])
                    };
                    customers.Add(customer);
                }
                con.Close();
            }
            return customers;
        }

        public Customer GetCustomerById(int? custId = 0)
        {
            Customer customer = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetCustomerById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@custId", custId);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                   customer = new Customer()
                    {
                        CustomerId = Convert.ToInt32(rdr["CustomerId"]),
                        Name = rdr["Name"].ToString(),
                        Address = rdr["Address"].ToString(),
                        Dob = (DateTime)rdr["Dob"],
                        Salary = (decimal)(rdr["Salary"])
                    };
                }
                con.Close();
            }
            return customer;
        }

        public int AddCustomer(Customer customer)
        {
            int custId = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddCustomers", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", customer.Name);
                cmd.Parameters.AddWithValue("@Address", customer.Address);
                cmd.Parameters.AddWithValue("@Dob", customer.Dob);
                cmd.Parameters.AddWithValue("@Salary", customer.Salary);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            return custId;
        }

        public int UpdateCustomer(Customer customer)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@custId", customer.CustomerId);
                cmd.Parameters.AddWithValue("@Name", customer.Name);
                cmd.Parameters.AddWithValue("@Address", customer.Address);
                cmd.Parameters.AddWithValue("@Dob", customer.Dob);
                cmd.Parameters.AddWithValue("@Salary", customer.Salary);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return 0;
        }

        public int DeleteCustomer(int? custId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@custId", custId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return 0;
        }
    }
}
