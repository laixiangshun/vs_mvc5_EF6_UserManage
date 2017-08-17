namespace mvc_EF_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Annotations1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Worker", "LastName", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Worker", "FirstName", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Worker", "FirstName", c => c.String(unicode: false));
            AlterColumn("dbo.Worker", "LastName", c => c.String(unicode: false));
        }
    }
}
