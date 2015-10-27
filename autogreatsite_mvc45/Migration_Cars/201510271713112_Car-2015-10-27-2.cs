namespace autogreatsite_mvc45.Migration_Cars
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Car201510272 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "IsMain", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Photos", "IsMain");
        }
    }
}
