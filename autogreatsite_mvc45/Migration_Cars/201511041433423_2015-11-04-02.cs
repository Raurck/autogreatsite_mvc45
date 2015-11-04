namespace autogreatsite_mvc45.Migration_Cars
{
    using System.Data.Entity.Migrations;
    
    public partial class _2015110402 : DbMigration
    {
        public override void Up()
        {
            DropIndex(table: "dbo.Cars", name: "IX_BrandId");
            DropForeignKey("dbo.Cars", "FK_dbo.Cars_dbo.Brands_BrandId");
            //DropIndex(table: "dbo.Cars", name: "FK_dbo.Cars_dbo.Brands_BrandId");
            DropColumn(table: "dbo.Cars", name: "BrandId");

        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "BrandId", c => c.Int(nullable: true));
            CreateIndex(table: "dbo.Cars", column: "BrandId",unique:false, name: "IX_BrandId");
            AddForeignKey("dbo.Cars", "BrandId", "dbo.Brands", name: "FK_dbo.Cars_dbo.Brands_BrandId");
            
        }
    }
}
