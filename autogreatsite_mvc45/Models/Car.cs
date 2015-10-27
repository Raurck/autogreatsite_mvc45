using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace autogreatsite_mvc45.Models
{
    public class Car
    {
        public int CarId { get; set; }

        [DisplayName("Модель")]
        public string Model { get; set; }

        [DisplayName("Производитель")]
        public int? BrandId { get; set; }
        [DisplayName("Производитель")]
        public virtual Brand CarBrand { get; set; }

        [DisplayName("Пробег")]
        public int DistanceTraveled { get; set; }

        [DisplayName("Цена")]
        public double Price { get; set; }

        [DisplayName("Год выпуска")]
        public int IssueYar { get; set; }

        [DisplayName("Кузов")]
        public int BodyId { get; set; }
        [DisplayName("Кузов")]
        public Body CarBody { get; set; }

        [DisplayName("Коробка перадач")]
        public int TransmissionId { get; set; }
        [DisplayName("Коробка перадач")]
        public Transmission CarTransmission { get; set; }

        [DisplayName("Положение руля")]
        public int RudderId { get; set; }
        [DisplayName("Положение руля")]
        public Rudder CarRudder { get; set; }

        [DisplayName("Число владельцев")]
        public int OwnerCount { get; set; }

        [DisplayName("Привод")]
        public int DriveId { get; set; }
        [DisplayName("Привод")]
        public Drive CarDrive { get; set; }

        [DisplayName("Двигатель")]
        public int? EngineId { get; set; }
        [DisplayName("Двигатель")]
        public virtual Engine CarEngine { get; set; }

        [DisplayName("Цвет")]
        public string CarColor { get; set; }

        [DisplayName("Дополнительное оборудование")]
        public virtual List<Features> CarFeatures { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        public virtual List<Photo> CarPhoto { get; set; }


    }
}
