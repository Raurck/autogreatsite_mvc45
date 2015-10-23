using System.Collections.Generic;

namespace autogreatsite_mvc45.Models
{
    public class Brand
    {
        public int BrandId { get; set; }

        public string BrandName { get; set; }

        public virtual List<Car> Cars { get; set; }
    }
}