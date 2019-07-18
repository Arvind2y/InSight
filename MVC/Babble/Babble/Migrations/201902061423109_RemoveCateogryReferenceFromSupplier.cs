namespace Babble.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCateogryReferenceFromSupplier : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Suppliers", "CategoryCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Suppliers", "CategoryCode", c => c.Int(nullable: false));
        }
    }
}
