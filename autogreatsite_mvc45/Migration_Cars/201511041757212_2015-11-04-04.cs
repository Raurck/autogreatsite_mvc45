namespace autogreatsite_mvc45.Migration_Cars
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2015110404 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "CatalogDate", c => c.DateTime());
            AddColumn("dbo.Cars", "RenewDate", c => c.DateTime());
            AddColumn("dbo.Cars", "SepcialDate", c => c.DateTime());
            AddColumn("dbo.Cars", "SellDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "SellDate");
            DropColumn("dbo.Cars", "SepcialDate");
            DropColumn("dbo.Cars", "RenewDate");
            DropColumn("dbo.Cars", "CatalogDate");
        }
    }
}
