namespace autogreatsite_mvc45.Migration_Cars
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2015110401 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        ModelId = c.Int(nullable: false, identity: true),
                        BrandId = c.Int(nullable: false),
                        ModelName = c.String(),
                    })
                .PrimaryKey(t => t.ModelId)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .Index(t => t.BrandId);
            
           DropTable("dbo.CarModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        ModelId = c.Int(nullable: false, identity: true),
                        ModelName = c.String(),
                    })
                .PrimaryKey(t => t.ModelId);
            
            DropForeignKey("dbo.Models", "BrandId", "dbo.Brands");
            DropIndex("dbo.Models", new[] { "BrandId" });
            DropTable("dbo.Models");
        }
    }
}
