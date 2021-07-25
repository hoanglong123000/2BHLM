namespace _2BHLM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStoredCarTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StoredCars",
                c => new
                    {
                        Idstore = c.Int(nullable: false, identity: true),
                        Titleofproduct = c.String(),
                        AmmountofProduct = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Idstore);
            
            AddColumn("dbo.Products", "Idstore", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "Idstore");
            AddForeignKey("dbo.Products", "Idstore", "dbo.StoredCars", "Idstore", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Idstore", "dbo.StoredCars");
            DropIndex("dbo.Products", new[] { "Idstore" });
            DropColumn("dbo.Products", "Idstore");
            DropTable("dbo.StoredCars");
        }
    }
}
