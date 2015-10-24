using System.Collections.Generic;
using System.ComponentModel;

namespace autogreatsite_mvc45.Models
{
    public class Drive
    {
        public int DriveID { get; set; }
        [DisplayName("Привод")]
        public string Name { get; set; }
        //public enum DriveType{ пердний, задний, полный }
        public virtual List<Car> Cars { get; set; }
    }
}