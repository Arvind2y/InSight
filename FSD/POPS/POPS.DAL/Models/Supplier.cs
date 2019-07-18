
namespace POPS.DAL.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Supplier
    {
        
        public int Id { get; set; }
        [Required]
        [Display(Name ="Supplier No")]
        public string SupplierNo { get; set; }
        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }
        [Display(Name = "Supplier Address")]
        public string SupplierAddress { get; set; }
    }
}