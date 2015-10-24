namespace autogreatsite_mvc45.Migration_Cars
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cars_3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.Cars", "EngineId", "dbo.Engines");
            DropIndex("dbo.Cars", new[] { "BrandId" });
            DropIndex("dbo.Cars", new[] { "EngineId" });
            AlterColumn("dbo.Cars", "BrandId", c => c.Int());
            AlterColumn("dbo.Cars", "EngineId", c => c.Int());
            CreateIndex("dbo.Cars", "BrandId");
            CreateIndex("dbo.Cars", "EngineId");
            AddForeignKey("dbo.Cars", "BrandId", "dbo.Brands", "BrandId");
            AddForeignKey("dbo.Cars", "EngineId", "dbo.Engines", "EngineId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "EngineId", "dbo.Engines");
            DropForeignKey("dbo.Cars", "BrandId", "dbo.Brands");
            DropIndex("dbo.Cars", new[] { "EngineId" });
            DropIndex("dbo.Cars", new[] { "BrandId" });
            AlterColumn("dbo.Cars", "EngineId", c => c.Int(nullable: false));
            AlterColumn("dbo.Cars", "BrandId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "EngineId");
            CreateIndex("dbo.Cars", "BrandId");
            AddForeignKey("dbo.Cars", "EngineId", "dbo.Engines", "EngineId", cascadeDelete: true);
            AddForeignKey("dbo.Cars", "BrandId", "dbo.Brands", "BrandId", cascadeDelete: true);
        }
    }
}
