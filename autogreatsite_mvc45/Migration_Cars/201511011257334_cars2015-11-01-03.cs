namespace autogreatsite_mvc45.Migration_Cars
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cars2015110103 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "ModelId", c => c.Int(nullable: true));
            CreateIndex("dbo.Cars", "ModelId");
            AddForeignKey("dbo.Cars", "ModelId", "dbo.CarModels", "ModelId", cascadeDelete: true);


        }

        public override void Down()
        {

            DropForeignKey("dbo.Cars", "ModelId", "dbo.CarModels");
            DropIndex("dbo.Cars", new[] { "ModelId" });
            DropColumn("dbo.Cars", "ModelId");

        }
    }
}
