namespace autogreatsite_mvc45.Migration_Cars
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StartCars : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bodies",
                c => new
                    {
                        BodyID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BodyID);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarId = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        BrandId = c.Int(nullable: false),
                        DistanceTraveled = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        IssueYar = c.Int(nullable: false),
                        CarBodyId = c.Int(nullable: false),
                        CarTransmissionId = c.Int(nullable: false),
                        CarRudderId = c.Int(nullable: false),
                        OwnerCount = c.Int(nullable: false),
                        CarDriveId = c.Int(nullable: false),
                        CarEngineId = c.Int(nullable: false),
                        CarColor = c.String(),
                        Description = c.String(),
                        CarBody_BodyID = c.Int(),
                        CarDrive_DriveID = c.Int(),
                        CarEngine_EngineId = c.Int(),
                        CarRudder_RudderID = c.Int(),
                        CarTransmission_TransmissionID = c.Int(),
                    })
                .PrimaryKey(t => t.CarId)
                .ForeignKey("dbo.Bodies", t => t.CarBody_BodyID)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.Drives", t => t.CarDrive_DriveID)
                .ForeignKey("dbo.Engines", t => t.CarEngine_EngineId)
                .ForeignKey("dbo.Rudders", t => t.CarRudder_RudderID)
                .ForeignKey("dbo.Transmissions", t => t.CarTransmission_TransmissionID)
                .Index(t => t.BrandId)
                .Index(t => t.CarBody_BodyID)
                .Index(t => t.CarDrive_DriveID)
                .Index(t => t.CarEngine_EngineId)
                .Index(t => t.CarRudder_RudderID)
                .Index(t => t.CarTransmission_TransmissionID);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandId = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                    })
                .PrimaryKey(t => t.BrandId);
            
            CreateTable(
                "dbo.Drives",
                c => new
                    {
                        DriveID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DriveID);
            
            CreateTable(
                "dbo.Engines",
                c => new
                    {
                        EngineId = c.Int(nullable: false, identity: true),
                        Volume = c.Double(nullable: false),
                        HorsePower = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.EngineId);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        FeaturesId = c.Int(nullable: false, identity: true),
                        Feature = c.String(),
                    })
                .PrimaryKey(t => t.FeaturesId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        PhotoId = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        Description = c.String(),
                        CarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhotoId)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.Rudders",
                c => new
                    {
                        RudderID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RudderID);
            
            CreateTable(
                "dbo.Transmissions",
                c => new
                    {
                        TransmissionID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Stages = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransmissionID);
            
            CreateTable(
                "dbo.FeaturesCars",
                c => new
                    {
                        Features_FeaturesId = c.Int(nullable: false),
                        Car_CarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Features_FeaturesId, t.Car_CarId })
                .ForeignKey("dbo.Features", t => t.Features_FeaturesId, cascadeDelete: true)
                .ForeignKey("dbo.Cars", t => t.Car_CarId, cascadeDelete: true)
                .Index(t => t.Features_FeaturesId)
                .Index(t => t.Car_CarId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "CarTransmission_TransmissionID", "dbo.Transmissions");
            DropForeignKey("dbo.Cars", "CarRudder_RudderID", "dbo.Rudders");
            DropForeignKey("dbo.Photos", "CarId", "dbo.Cars");
            DropForeignKey("dbo.FeaturesCars", "Car_CarId", "dbo.Cars");
            DropForeignKey("dbo.FeaturesCars", "Features_FeaturesId", "dbo.Features");
            DropForeignKey("dbo.Cars", "CarEngine_EngineId", "dbo.Engines");
            DropForeignKey("dbo.Cars", "CarDrive_DriveID", "dbo.Drives");
            DropForeignKey("dbo.Cars", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.Cars", "CarBody_BodyID", "dbo.Bodies");
            DropIndex("dbo.FeaturesCars", new[] { "Car_CarId" });
            DropIndex("dbo.FeaturesCars", new[] { "Features_FeaturesId" });
            DropIndex("dbo.Photos", new[] { "CarId" });
            DropIndex("dbo.Cars", new[] { "CarTransmission_TransmissionID" });
            DropIndex("dbo.Cars", new[] { "CarRudder_RudderID" });
            DropIndex("dbo.Cars", new[] { "CarEngine_EngineId" });
            DropIndex("dbo.Cars", new[] { "CarDrive_DriveID" });
            DropIndex("dbo.Cars", new[] { "CarBody_BodyID" });
            DropIndex("dbo.Cars", new[] { "BrandId" });
            DropTable("dbo.FeaturesCars");
            DropTable("dbo.Transmissions");
            DropTable("dbo.Rudders");
            DropTable("dbo.Photos");
            DropTable("dbo.Features");
            DropTable("dbo.Engines");
            DropTable("dbo.Drives");
            DropTable("dbo.Brands");
            DropTable("dbo.Cars");
            DropTable("dbo.Bodies");
        }
    }
}
