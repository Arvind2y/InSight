namespace POPS.DAL.Models
{
    using System.Data.Entity;

    public class POPSDbContext : DbContext
    {
        public POPSDbContext() : base("name=POPSDbContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<POMaster> POMasters { get; set; }
        public virtual DbSet<PODetail> PODetails { get; set; }
    }
}
