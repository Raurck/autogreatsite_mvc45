using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace autogreatsite_mvc45.Models
{
    public class Finder
    {
        [DisplayName("Модель")]
        public string Model { get; set; }
        [DisplayName("Производитель")]
        public int? BrandId { get; set; }
        [DisplayName("Производитель")]
        public IQueryable<BrandDTO> CarBrands { get;}
        [DisplayName("Цена")]
        [DisplayFormat(DataFormatString = "{0:### ### ### ###}")]
        public double Price { get; set; }
        [DisplayName("Год выпуска")]
        [DefaultValue(2010)]
        public int IssueYar { get; set; }

        public int minYear = 1950;
        public int maxYear = DateTime.Now.Year;

        public double minPrice = 0;
        public double maxPrice = int.MaxValue;

        public Finder(CarContext Cars)
        {
            CarBrands = Cars.Brands.Join(Cars.Cars, c => c.BrandId, p => p.BrandId, (c, p) => new BrandDTO { BrandId = c.BrandId, BrandName = c.BrandName, LogoName = c.LogoName }).Distinct();
            //CarModels
        }
    }
}