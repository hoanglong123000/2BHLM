namespace _2BHLM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMarketDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetailProducts",
                c => new
                    {
                        No = c.Int(nullable: false, identity: true),
                        Madein = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        NutriousInfo = c.String(),
                        ProducedTime = c.DateTime(nullable: false),
                        ExpiredDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.No);
            
            CreateTable(
                "dbo.DetailReceipts",
                c => new
                    {
                        IDReceipt = c.Int(nullable: false, identity: true),
                        ReceiptDate = c.DateTime(nullable: false),
                        ProductAmmount = c.Int(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IDReceipt);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        IDproduct = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Price = c.Double(nullable: false),
                        Description = c.String(),
                        IDReceipt = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDproduct)
                .ForeignKey("dbo.DetailReceipts", t => t.IDReceipt, cascadeDelete: true)
                .Index(t => t.IDReceipt);
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        IDUserInfo = c.Int(nullable: false, identity: true),
                        IDproduct = c.Int(nullable: false),
                        CustomerID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.IDUserInfo)
                .ForeignKey("dbo.AspNetUsers", t => t.CustomerID)
                .ForeignKey("dbo.Products", t => t.IDproduct, cascadeDelete: true)
                .Index(t => t.IDproduct)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.UserInfoes", "IDproduct", "dbo.Products");
            DropForeignKey("dbo.UserInfoes", "CustomerID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "IDReceipt", "dbo.DetailReceipts");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.UserInfoes", new[] { "CustomerID" });
            DropIndex("dbo.UserInfoes", new[] { "IDproduct" });
            DropIndex("dbo.Products", new[] { "IDReceipt" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserInfoes");
            DropTable("dbo.Products");
            DropTable("dbo.DetailReceipts");
            DropTable("dbo.DetailProducts");
        }
    }
}
