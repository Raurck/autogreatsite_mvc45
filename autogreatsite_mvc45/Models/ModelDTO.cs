using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace autogreatsite_mvc45.Models
{
    public class ModelDTO
    {
        public int ModelId { get; set; }
        public int BrandId { get; set; }
        [DisplayName("Модель")]
        public string ModelName { get; set; }


    }
}