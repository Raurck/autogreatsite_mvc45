using System.Collections.Generic;
namespace autogreatsite_mvc45.Models
{
    public class Engine
    {
        public int EngineId { get; set; }

        public double Volume { get; set; }

        public double HorsePower { get; set; }

        public virtual List<Car> Cars { get; set; }
    }
}