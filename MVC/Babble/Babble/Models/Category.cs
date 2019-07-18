using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Babble.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [DisplayName("Category Code")]
        public int CategoryCode { get; set; }
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
        public string Division { get; set; }
        public string Region { get; set; }
        public int SupplierId { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }

    }
}