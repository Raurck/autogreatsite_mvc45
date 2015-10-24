namespace autogreatsite_mvc45.Migration_Cars
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cars1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Transmissions", "Stages");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transmissions", "Stages", c => c.Int(nullable: false));
        }
    }
}
