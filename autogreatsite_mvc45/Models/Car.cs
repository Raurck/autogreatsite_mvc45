using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace autogreatsite_mvc45.Models
{
    public class Car
    {
        public int CarId { get; set; }

        public string Model { get; set; }

        public int BrandId { get; set; }
        public Brand CarBrand { get; set; }

        public int DistanceTraveled { get; set; }

        public double Price { get; set; }

        public int IssueYar { get; set; }

        public int CarBodyId { get; set; }
        public Body CarBody { get; set; }

        public int CarTransmissionId { get; set; }
        public Transmission CarTransmission { get; set; }

        public int CarRudderId { get; set; }
        public Rudder CarRudder { get; set; }

        public int OwnerCount { get; set; }

        public int CarDriveId { get; set; }
        public Drive CarDrive { get; set; }

        public int CarEngineId { get; set; }
        public Engine CarEngine { get; set; }

        public string CarColor { get; set; }

        public virtual List<Features> CarFeatures { get; set; }

        public string Description { get; set; }

        public virtual List<Photo> CarPhoto { get; set; }


    }
}
