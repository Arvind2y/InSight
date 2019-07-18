
namespace POPS.DAL.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class POMaster
    {
        public int Id { get; set; }
        [Required]
        public string PONumber { get; set; }
        [Required]
        public DateTime? PODate { get; set; }

        // Foreign Key
        public int SupplierId { get; set; }
        // Navigation property
       public virtual Supplier Supplier { get; set; }
    }
}