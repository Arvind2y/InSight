namespace Babble.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingcategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryCode = c.Int(nullable: false),
                        CategoryName = c.String(),
                        Division = c.String(),
                        Region = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            AddColumn("dbo.Suppliers", "Category_CategoryId", c => c.Int());
            CreateIndex("dbo.Suppliers", "Category_CategoryId");
            AddForeignKey("dbo.Suppliers", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Suppliers", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Suppliers", new[] { "Category_CategoryId" });
            DropColumn("dbo.Suppliers", "Category_CategoryId");
            DropTable("dbo.Categories");
        }
    }
}
