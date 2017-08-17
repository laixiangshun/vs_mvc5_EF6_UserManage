namespace mvc_EF_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Annotations2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityName = c.String(unicode: false),
                        provinceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.Province",
                c => new
                    {
                        provinceId = c.Int(nullable: false, identity: true),
                        provinceName = c.String(unicode: false),
                        Abbr = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.provinceId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        userName = c.String(nullable: false, unicode: false),
                        address = c.String(nullable: false, unicode: false),
                        Province = c.String(nullable: false, unicode: false),
                        City = c.String(nullable: false, unicode: false),
                        ZipCode = c.String(unicode: false),
                        phone = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
            DropTable("dbo.Province");
            DropTable("dbo.City");
        }
    }
}
