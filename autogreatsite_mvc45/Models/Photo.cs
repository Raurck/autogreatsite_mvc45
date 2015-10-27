using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace autogreatsite_mvc45.Models
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public bool IsMain {get; set;}
        public string FileName { get; set; }
        public string Description { get; set; }
        public int CarId { get; set; }
        public virtual Car  Car { get; set; }
    }
}