using System;
using System.Collections.Generic;

namespace CMS.Web.DbModels
{
    public partial class Customers
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime? Dob { get; set; }
        public decimal? Salary { get; set; }
    }
}
