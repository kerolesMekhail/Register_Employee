namespace CRM2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emp24 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee_data", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee_data", "Image");
        }
    }
}
