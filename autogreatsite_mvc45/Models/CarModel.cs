using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace autogreatsite_mvc45.Models
{
    public class Model
    {
        [Key]
        public int ModelId { get; set; }
        [DisplayName("Производитель")]
        public int BrandId { get; set; }

        [DisplayName("Модель")]
        public string ModelName { get; set; }
        public virtual List<Car> Cars { get; set; }
        [DisplayName("Производитель")]
        public virtual Brand Brand { get; set; }
    }
}