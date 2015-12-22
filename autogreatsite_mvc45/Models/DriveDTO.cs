using System.Collections.Generic;
using System.ComponentModel;

namespace autogreatsite_mvc45.Models
{
    public class DriveDTO
    {
        public int DriveID { get; set; }
        [DisplayName("Привод")]
        public string Name { get; set; }
    }
}