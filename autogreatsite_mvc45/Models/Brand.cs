using System.Collections.Generic;
using System.ComponentModel;

namespace autogreatsite_mvc45.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        [DisplayName("Производитель")]
        public string BrandName { get; set; }

        public virtual List<Car> Cars { get; set; }
    }
}