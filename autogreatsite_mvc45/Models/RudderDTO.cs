using System.Collections.Generic;
using System.ComponentModel;
namespace autogreatsite_mvc45.Models
{
    public class RudderDTO
    {
        public int RudderID { get; set; }
        [DisplayName("Руль")]
        public string Name { get; set; }
    }
}