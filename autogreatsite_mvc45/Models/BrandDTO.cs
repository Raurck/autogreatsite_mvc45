using System.Collections.Generic;
using System.ComponentModel;

namespace autogreatsite_mvc45.Models
{
    public class BrandDTO
    {
        public int BrandId { get; set; }
        [DisplayName("Производитель")]
        public string BrandName { get; set; }
        [DisplayName("Файл логотипа")]
        public string LogoName { get; set; } = "";
    }
}