
namespace POPS.DAL.Migrations
{
    using POPS.DAL.Models;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<POPSDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(POPSDbContext context)
        {
            context.Items.AddOrUpdate(x => x.Id,
                    new Item() { Id = 1, ItemCode = "I001", ItemDescription = "Nut", ItemRate = 5.7500m },
                    new Item() { Id = 2, ItemCode = "I002", ItemDescription = "Bolt", ItemRate = 3.2500m },
                    new Item() { Id = 3, ItemCode = "I003", ItemDescription = "Screw", ItemRate = 1.7500m },
                    new Item() { Id = 4, ItemCode = "I004", ItemDescription = "ScrewRound", ItemRate = 2.4500m },
                    new Item() { Id = 5, ItemCode = "I005", ItemDescription = "Cam", ItemRate = 7.7500m },
                    new Item() { Id = 6, ItemCode = "I006", ItemDescription = "Cog", ItemRate = 9.9900m }
                );

            context.Suppliers.AddOrUpdate(x => x.Id,
                new Supplier() { Id = 1, SupplierNo = "S001", SupplierName = "Smith", SupplierAddress = "London" },
                new Supplier() { Id = 2, SupplierNo = "S002", SupplierName = "Jones", SupplierAddress = "Paris" },
                new Supplier() { Id = 3, SupplierNo = "S003", SupplierName = "Blake", SupplierAddress = "Paris" },
                new Supplier() { Id = 4, SupplierNo = "S004", SupplierName = "Clark", SupplierAddress = "London" },
                new Supplier() { Id = 5, SupplierNo = "S005", SupplierName = "Adams", SupplierAddress = "Athens" }
                );

            context.POMasters.AddOrUpdate(x => x.Id,
                new POMaster() { Id = 1, PONumber = "P001", PODate = new DateTime(2019, 01, 10), SupplierId = 1 },
                new POMaster() { Id = 2, PONumber = "P002", PODate = new DateTime(2019, 01, 10), SupplierId = 1 },
                new POMaster() { Id = 3, PONumber = "P003", PODate = new DateTime(2019, 01, 11), SupplierId = 1 },
                new POMaster() { Id = 4, PONumber = "P004", PODate = new DateTime(2019, 01, 11), SupplierId = 2 },
                new POMaster() { Id = 5, PONumber = "P005", PODate = new DateTime(2019, 01, 11), SupplierId = 2 },
                new POMaster() { Id = 6, PONumber = "P006", PODate = new DateTime(2019, 01, 2), SupplierId = 3 }
                );

            context.PODetails.AddOrUpdate(x => x.Id,
                new PODetail() { Id = 1, PoId = 1, ItemId = 1, Quantity = 5 },
                new PODetail() { Id = 2, PoId = 1, ItemId = 2, Quantity = 5 },
                new PODetail() { Id = 3, PoId = 1, ItemId = 3, Quantity = 25 },
                new PODetail() { Id = 4, PoId = 1, ItemId = 4, Quantity = 10 },
                new PODetail() { Id = 5, PoId = 2, ItemId = 2, Quantity = 12 },
                new PODetail() { Id = 5, PoId = 2, ItemId = 4, Quantity = 15 },
                new PODetail() { Id = 5, PoId = 2, ItemId = 5, Quantity = 5 },
                new PODetail() { Id = 5, PoId = 2, ItemId = 6, Quantity = 20 }
                );

            base.Seed(context);
        }
    }
}
