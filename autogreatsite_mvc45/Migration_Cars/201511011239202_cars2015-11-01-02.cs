namespace autogreatsite_mvc45.Migration_Cars
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cars2015110102 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        ModelId = c.Int(nullable: false, identity: true),
                        ModelName = c.String(),
                    })
                .PrimaryKey(t => t.ModelId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CarModels");
        }
    }
}
