using System.Collections.Generic;
using System.ComponentModel;
namespace autogreatsite_mvc45.Models
{
    public class Transmission
    {
        public int TransmissionID { get; set; }
        [DisplayName("Коробка передач")]
        public string Name { get; set; }
    }
}