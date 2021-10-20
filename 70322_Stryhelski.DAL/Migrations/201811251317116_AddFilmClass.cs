namespace _70322_Stryhelski.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFilmClass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Films", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Films", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Films", "Category", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Films", "Category", c => c.String());
            AlterColumn("dbo.Films", "Description", c => c.String());
            AlterColumn("dbo.Films", "Name", c => c.String());
        }
    }
}
