
namespace POPS.DAL.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PODetail
    {
        public int Id { get; set; }

        //Foriegn id
        [Required]
        public int PoId { get; set; }
        public int? Quantity { get; set; }
        //Foriegn id
        public Int16 ItemId { get; set; }
        //Navigation propery
        public virtual Item Item { get; set; }
    }
}