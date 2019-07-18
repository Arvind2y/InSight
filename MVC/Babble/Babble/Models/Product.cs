using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Babble.Models
{
    public class Product
    {
        /*
         Consider a table called Product Details having a columns of Product id, Product Name, Supplier id. Also consider a table called Supplier Info with columns of Supplier ID, Supplier Name, Address, City, Contact No, and Email. Create a class file that should have the following functions :
            a.	Get all records of Product Details Table
            b.	Get all records of Supplier Info Table

         */

        [DisplayName("Product Id")]
        public int ProductId { get; set; }

        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [DisplayName("Supplier Id")]
        public int SupplierId { get; set; }
    }
}