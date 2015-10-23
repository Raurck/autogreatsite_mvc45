using System.Collections.Generic;
namespace autogreatsite_mvc45.Models
{
    public class Rudder
    {
        public enum RudderType { левый,правый }
        public virtual List<Car> Cars { get; set; }
    }
}