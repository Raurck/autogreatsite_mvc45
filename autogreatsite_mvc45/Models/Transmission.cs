using System.Collections.Generic;
namespace autogreatsite_mvc45.Models
{
    public class Transmission
    {
        public enum TransmissionType { АКПП, МКПП, CVT }
        public int Stages { get; set; }
        public virtual List<Car> Cars { get; set; }
    }
}