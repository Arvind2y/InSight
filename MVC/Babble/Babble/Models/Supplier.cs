using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Babble.Models
{
    public class Supplier
    {
        [DisplayName("Supplier Id")]
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        //public int CategoryId { get; set; }
        //public Category Category { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}