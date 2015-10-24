using System.Collections.Generic;
using System.ComponentModel;
namespace autogreatsite_mvc45.Models
{
    public class Transmission
    {
        public int TransmissionID { get; set; }
        [DisplayName("Коробка пердач")]
        public string Name { get; set; }
        //public enum TransmissionType { АКПП, МКПП, CVT }
        //public int Stages { get; set; }
        public virtual List<Car> Cars { get; set; }
    }
}