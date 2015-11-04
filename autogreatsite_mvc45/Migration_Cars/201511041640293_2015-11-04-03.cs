namespace autogreatsite_mvc45.Migration_Cars
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2015110403 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "Brand_BrandId", "dbo.Brands");
            DropIndex("dbo.Cars", new[] { "Brand_BrandId" });
            DropColumn("dbo.Cars", "Brand_BrandId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Brand_BrandId", c => c.Int());
            CreateIndex("dbo.Cars", "Brand_BrandId");
            AddForeignKey("dbo.Cars", "Brand_BrandId", "dbo.Brands", "BrandId");
        }
    }
}
