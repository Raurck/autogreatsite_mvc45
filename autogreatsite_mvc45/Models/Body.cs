using System.Collections.Generic;
using System.ComponentModel;

namespace autogreatsite_mvc45.Models

{
    public class Body
    {
        public int BodyID { get; set; }
        [DisplayName("Кузов")]
        public string Name { get; set; }
        public virtual List<Car> Cars { get; set; }
    }
}