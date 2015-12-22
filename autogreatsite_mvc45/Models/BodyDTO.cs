using System.Collections.Generic;
using System.ComponentModel;

namespace autogreatsite_mvc45.Models

{
    public class BodyDTO
    {
        public int BodyID { get; set; }
        [DisplayName("Кузов")]
        public string Name { get; set; }
    }
}