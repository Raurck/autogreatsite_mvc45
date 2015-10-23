using System.Collections.Generic;

namespace autogreatsite_mvc45.Models
{
    public class Photo
    {
        public int PhotoId { get; set; }

        public string FileName { get; set; }

        public string Description { get; set; }

        public int CarId { get; set; }
        public Car  Car { get; set; }
    }
}