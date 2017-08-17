namespace mvc_EF_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Annotations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(unicode: false),
                        Name = c.String(maxLength: 60, storeType: "nvarchar"),
                        Author = c.String(unicode: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Deleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                        yuyan = c.String(maxLength: 20, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Worker",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(unicode: false),
                        FirstName = c.String(unicode: false),
                        Sex = c.Int(nullable: false),
                        Rating = c.Double(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Worker");
            DropTable("dbo.Employee");
            DropTable("dbo.BookInfo");
        }
    }
}
