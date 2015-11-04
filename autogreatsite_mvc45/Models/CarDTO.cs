using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace autogreatsite_mvc45.Models
{
    public class CarDTO
    {

        [DisplayName("Модель")]
        public string Model { get; set; }
        [DisplayName("Модель")]
        public virtual Model CarModel { get; set; }

        [DisplayName("Пробег")]
        public int DistanceTraveled { get; set; }

        [DisplayName("Цена")]
        [DisplayFormat(DataFormatString = "{0:### ### ### ###}")]
        public double Price { get; set; }

        [DisplayName("Год выпуска")]
        [DefaultValue(2010)]
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

     
        private List<Photo> _CarPhoto;
        [DisplayName("Фотографии")]
        public virtual List<Photo> CarPhoto { get
            {
                if (_CarPhoto == null) {
                    _CarPhoto = new List<Photo>();
                }
                return _CarPhoto;
            } set { _CarPhoto = value; } }


    }
}
