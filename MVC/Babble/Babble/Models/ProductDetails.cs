using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Babble.Models
{


    

    public class ProductManager
    {
        public ICollection<Product> GetAllProducts()
        {
            return new List<Product>();
        }
    }

    public class SupplierManager
    {
        public ICollection<Supplier> GetSuppliers()
        {
            return new List<Supplier>();
        }

    }
}