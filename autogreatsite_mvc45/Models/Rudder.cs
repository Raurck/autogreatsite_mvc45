using System.Collections.Generic;
using System.ComponentModel;
namespace autogreatsite_mvc45.Models
{
    public class Rudder
    {
        public int RudderID { get; set; }
        [DisplayName("Положение руля")]
        public string Name { get; set; }
       // public enum RudderType { левый,правый }
        public virtual List<Car> Cars { get; set; }
    }
}