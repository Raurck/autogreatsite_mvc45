using System.Collections.Generic;
namespace autogreatsite_mvc45.Models
{
    public class Body
    {
        public int BodyID { get; set; }
        public string Name { get; set; }
        public virtual List<Car> Cars { get; set; }
    }
}