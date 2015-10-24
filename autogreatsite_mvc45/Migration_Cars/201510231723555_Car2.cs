namespace autogreatsite_mvc45.Migration_Cars
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Car2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "CarBody_BodyID", "dbo.Bodies");
            DropForeignKey("dbo.Cars", "CarDrive_DriveID", "dbo.Drives");
            DropForeignKey("dbo.Cars", "CarEngine_EngineId", "dbo.Engines");
            DropForeignKey("dbo.Cars", "CarRudder_RudderID", "dbo.Rudders");
            DropForeignKey("dbo.Cars", "CarTransmission_TransmissionID", "dbo.Transmissions");
            DropIndex("dbo.Cars", new[] { "CarBody_BodyID" });
            DropIndex("dbo.Cars", new[] { "CarDrive_DriveID" });
            DropIndex("dbo.Cars", new[] { "CarEngine_EngineId" });
            DropIndex("dbo.Cars", new[] { "CarRudder_RudderID" });
            DropIndex("dbo.Cars", new[] { "CarTransmission_TransmissionID" });
            RenameColumn(table: "dbo.Cars", name: "CarBody_BodyID", newName: "BodyId");
            RenameColumn(table: "dbo.Cars", name: "CarDrive_DriveID", newName: "DriveId");
            RenameColumn(table: "dbo.Cars", name: "CarEngine_EngineId", newName: "EngineId");
            RenameColumn(table: "dbo.Cars", name: "CarRudder_RudderID", newName: "RudderId");
            RenameColumn(table: "dbo.Cars", name: "CarTransmission_TransmissionID", newName: "TransmissionId");
            AlterColumn("dbo.Cars", "BodyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Cars", "DriveId", c => c.Int(nullable: false));
            AlterColumn("dbo.Cars", "EngineId", c => c.Int(nullable: false));
            AlterColumn("dbo.Cars", "RudderId", c => c.Int(nullable: false));
            AlterColumn("dbo.Cars", "TransmissionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "BodyId");
            CreateIndex("dbo.Cars", "TransmissionId");
            CreateIndex("dbo.Cars", "RudderId");
            CreateIndex("dbo.Cars", "DriveId");
            CreateIndex("dbo.Cars", "EngineId");
            AddForeignKey("dbo.Cars", "BodyId", "dbo.Bodies", "BodyID", cascadeDelete: true);
            AddForeignKey("dbo.Cars", "DriveId", "dbo.Drives", "DriveID", cascadeDelete: true);
            AddForeignKey("dbo.Cars", "EngineId", "dbo.Engines", "EngineId", cascadeDelete: true);
            AddForeignKey("dbo.Cars", "RudderId", "dbo.Rudders", "RudderID", cascadeDelete: true);
            AddForeignKey("dbo.Cars", "TransmissionId", "dbo.Transmissions", "TransmissionID", cascadeDelete: true);
            DropColumn("dbo.Cars", "CarBodyId");
            DropColumn("dbo.Cars", "CarTransmissionId");
            DropColumn("dbo.Cars", "CarRudderId");
            DropColumn("dbo.Cars", "CarDriveId");
            DropColumn("dbo.Cars", "CarEngineId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "CarEngineId", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "CarDriveId", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "CarRudderId", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "CarTransmissionId", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "CarBodyId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Cars", "TransmissionId", "dbo.Transmissions");
            DropForeignKey("dbo.Cars", "RudderId", "dbo.Rudders");
            DropForeignKey("dbo.Cars", "EngineId", "dbo.Engines");
            DropForeignKey("dbo.Cars", "DriveId", "dbo.Drives");
            DropForeignKey("dbo.Cars", "BodyId", "dbo.Bodies");
            DropIndex("dbo.Cars", new[] { "EngineId" });
            DropIndex("dbo.Cars", new[] { "DriveId" });
            DropIndex("dbo.Cars", new[] { "RudderId" });
            DropIndex("dbo.Cars", new[] { "TransmissionId" });
            DropIndex("dbo.Cars", new[] { "BodyId" });
            AlterColumn("dbo.Cars", "TransmissionId", c => c.Int());
            AlterColumn("dbo.Cars", "RudderId", c => c.Int());
            AlterColumn("dbo.Cars", "EngineId", c => c.Int());
            AlterColumn("dbo.Cars", "DriveId", c => c.Int());
            AlterColumn("dbo.Cars", "BodyId", c => c.Int());
            RenameColumn(table: "dbo.Cars", name: "TransmissionId", newName: "CarTransmission_TransmissionID");
            RenameColumn(table: "dbo.Cars", name: "RudderId", newName: "CarRudder_RudderID");
            RenameColumn(table: "dbo.Cars", name: "EngineId", newName: "CarEngine_EngineId");
            RenameColumn(table: "dbo.Cars", name: "DriveId", newName: "CarDrive_DriveID");
            RenameColumn(table: "dbo.Cars", name: "BodyId", newName: "CarBody_BodyID");
            CreateIndex("dbo.Cars", "CarTransmission_TransmissionID");
            CreateIndex("dbo.Cars", "CarRudder_RudderID");
            CreateIndex("dbo.Cars", "CarEngine_EngineId");
            CreateIndex("dbo.Cars", "CarDrive_DriveID");
            CreateIndex("dbo.Cars", "CarBody_BodyID");
            AddForeignKey("dbo.Cars", "CarTransmission_TransmissionID", "dbo.Transmissions", "TransmissionID");
            AddForeignKey("dbo.Cars", "CarRudder_RudderID", "dbo.Rudders", "RudderID");
            AddForeignKey("dbo.Cars", "CarEngine_EngineId", "dbo.Engines", "EngineId");
            AddForeignKey("dbo.Cars", "CarDrive_DriveID", "dbo.Drives", "DriveID");
            AddForeignKey("dbo.Cars", "CarBody_BodyID", "dbo.Bodies", "BodyID");
        }
    }
}
