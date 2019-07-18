namespace POPS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemCode = c.String(nullable: false),
                        ItemDescription = c.String(),
                        ItemRate = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PODetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PoId = c.Int(nullable: false),
                        Quantity = c.Int(),
                        ItemId = c.Short(nullable: false),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.POMasters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PONumber = c.String(nullable: false),
                        PODate = c.DateTime(nullable: false),
                        SupplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupplierNo = c.String(nullable: false),
                        SupplierName = c.String(),
                        SupplierAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.POMasters", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.PODetails", "Item_Id", "dbo.Items");
            DropIndex("dbo.POMasters", new[] { "SupplierId" });
            DropIndex("dbo.PODetails", new[] { "Item_Id" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.POMasters");
            DropTable("dbo.PODetails");
            DropTable("dbo.Items");
        }
    }
}
