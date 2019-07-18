namespace POPS.DAL.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Item
    {
        public int Id { get; set; }

        [Required]
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public Nullable<decimal> ItemRate { get; set; }
    }
}