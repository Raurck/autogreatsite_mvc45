namespace autogreatsite_mvc45.Migration_Cars
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cars2015110104 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "ModelId", "dbo.CarModels");
            DropIndex("dbo.Cars", new[] { "ModelId" });
            AlterColumn("dbo.Cars", "ModelId", c => c.Int());
            CreateIndex("dbo.Cars", "ModelId");
            AddForeignKey("dbo.Cars", "ModelId", "dbo.CarModels", "ModelId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "ModelId", "dbo.CarModels");
            DropIndex("dbo.Cars", new[] { "ModelId" });
            AlterColumn("dbo.Cars", "ModelId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "ModelId");
            AddForeignKey("dbo.Cars", "ModelId", "dbo.CarModels", "ModelId", cascadeDelete: true);
        }
    }
}
