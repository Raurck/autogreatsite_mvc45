using System.Collections.Generic;

namespace autogreatsite_mvc45.Models

{
    public class Features
    {
        public int FeaturesId { get; set; }
        public string Feature { get; set; }

        public virtual List<Car> Cars { get; set; }
    }
}