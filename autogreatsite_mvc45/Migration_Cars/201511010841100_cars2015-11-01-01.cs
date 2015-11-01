namespace autogreatsite_mvc45.Migration_Cars
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cars2015110101 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brands", "LogoName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Brands", "LogoName");
        }
    }
}
