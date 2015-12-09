using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace autogreatsite_mvc45.Models
{
    public class Finder
    {
        const string C_STR_ALL = "All";
        const string C_STR_ALL_RUS = "Любой";
        const string C_STR_ALL_RUS_F = "Любая";
        const string C_STR_MIN = "_min";
        const string C_STR_MAX = "_max";
        const string C_STR_YEARS = "years";
        const string C_STR_PRICE = "price";
        const string C_STR_BODY = "body";
        const string C_STR_COLOR = "color";
        const string C_STR_RUDDER = "rudder";
        const string C_STR_DRIVE = "drive";
        const string C_STR_TRANSMISION = "transmission";
        const string C_STR_DISTANCE = "distance";

        private static bool isInit = false;
        static public List<ModelDTO> CarModels { get; set; }
        static public List<BrandDTO> CarBrands { get; set; }

        static public List<BodyDTO> CarBodys { get; set; }
        static public List<RudderDTO> CarRudders { get; set; }
        static public List<DriveDTO> CarDrives { get; set; }
        static public List<TransmissionDTO> CarTranssmisisons { get; set; }

        static public int minYear = 1950;
        static public int maxYear = DateTime.Now.Year;

        static public double minPrice = 0;
        static public double maxPrice = int.MaxValue;

        static private int CarsCount = -1;

        [DisplayName("Производитель")]
        public int f_brandId { get; set; }

        [DisplayName("Модель")]
        public int f_modelId { get; set; }

        [DisplayName("Цена(min)")]
        public int f_minPrice { get; set; }
        [DisplayName("Цена(max)")]
        public int f_maxPrice { get; set; }

        [DisplayName("Год производства(min)")]
        public int f_minYear { get; set; }
        [DisplayName("Год производства(max)")]
        public int f_maxYear { get; set; }

        [DisplayName("Пробег(min)")]
        public int f_minDistance { get; set; }
        [DisplayName("Пробег(max)")]
        public int f_maxDistance { get; set; }

        [DisplayName("Двигатель")]
        public int f_Engine { get; set; }

        [DisplayName("Двигатель(min)")]
        public int f_minEngine { get; set; }
        [DisplayName("Двигатель(max)")]
        public int f_maxEngine { get; set; }

        [DisplayName("Кузов")]
        public int f_bodyType { get; set; }
        [DisplayName("Привод")]
        public int f_drive { get; set; }
        [DisplayName("Руль")]
        public int f_rudder { get; set; }
        [DisplayName("Коробка")]
        public int f_transmission { get; set; }
        [DisplayName("Цвет")]
        public int f_color { get; set; }

        public string ToSearchString()
        {
            StringBuilder sb = new StringBuilder();

            var brand = CarBrands.FirstOrDefault(c => c.BrandId == f_brandId) ?? new BrandDTO { BrandId = -1, BrandName = C_STR_ALL };
            var model = CarModels.FirstOrDefault(c => c.ModelId == f_modelId) ?? new ModelDTO { ModelId = -1, ModelName = C_STR_ALL };
            //var brand = (f_brandId != -1 ? CarBrands.FirstOrDefault(c => c.BrandId == f_brandId).BrandName : C_STR_ALL);
            //var model = (f_modelId != -1 ? CarModels.FirstOrDefault(c => c.ModelId == f_modelId).ModelName : C_STR_ALL);
            sb.AppendFormat("{0}/{1}/{2}/{3}/{4}/{5}/{6}/{7}", brand.BrandId==-1? C_STR_ALL : brand.BrandName, model.ModelId==-1? C_STR_ALL: model.ModelName,C_STR_YEARS, f_minYear, f_maxYear, C_STR_PRICE, f_minPrice, f_maxPrice);
 
            /*
            StringBuilder sb1 = new StringBuilder("?");
            if (f_minDistance != 0)
            {
                sb1.Append(C_STR_DISTANCE);
                sb1.Append(C_STR_MIN);
                sb1.Append('=');
                sb1.Append(f_minDistance);
            }
            if (sb1.ToString() != "?")
            {
                sb.Append(sb1.ToString());
            }
            */
            //this.GetQueryString();
            return sb.ToString();
        }
        
        public static string getFiltredModelDropDownList(int brandId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<select class=\"form-control\" id=\"f_modelId\" name=\"f_modelId\"><option value = \" - 1\" > Все модели</option>");
            //foreach (var el in new SelectList(CarModels.OrderBy(c => c.ModelId).Where(c => c.BrandId == brandId), "ModelId", "ModelName"))
            List<ModelDTO> modelList;
            if (brandId != -1)
            {
                modelList = CarModels.OrderBy(c => c.ModelId).Where(c => c.BrandId == brandId).ToList();
            }
            else
            {
                modelList = CarModels.OrderBy(c => c.ModelId).ToList();
            }

            foreach (var el in modelList)
            {
                if (el.ModelId == -1)
                {
                    continue;
                }
                sb.Append("<option value = \"" + el.ModelId.ToString() + "\">" + el.ModelName + "</option>");
            }
            sb.Append("</select>");

            return sb.ToString();
        }
        public Finder()
        {
        }

        public Finder(CarContext Cars)
        {
            var _carsCount = Cars.Cars.Count();
            if (!isInit)
            {

                CarBodys = Cars.Bodys.Select(c=>new BodyDTO {BodyID= c.BodyID, Name= c.Name }).ToList();
                CarBodys.Add(new BodyDTO { BodyID = -1, Name = C_STR_ALL_RUS });

                CarRudders = Cars.Rudders.Select(c => new RudderDTO { RudderID = c.RudderID, Name = c.Name }).ToList();
                CarRudders.Add(new RudderDTO { RudderID = -1, Name = C_STR_ALL_RUS });

                CarDrives = Cars.Drives.Select(c => new DriveDTO { DriveID = c.DriveID, Name = c.Name }).ToList();
                CarDrives.Add(new DriveDTO { DriveID = -1, Name = C_STR_ALL_RUS });

                CarTranssmisisons = Cars.Transmissions.Select(c => new TransmissionDTO { TransmissionID = c.TransmissionID, Name = c.Name }).ToList();
                CarTranssmisisons.Add(new TransmissionDTO { TransmissionID = -1, Name = C_STR_ALL_RUS_F });
                //static public List<TransmissionDTO> CarTranssmisisons { get; set; }


                isInit = true;
            }
            if ((CarsCount != _carsCount) && (_carsCount > 0))
            {
                CarsCount = _carsCount;
                CarBrands = Cars.Brands.Join(Cars.Cars, c => c.BrandId, p => p.CarModel.BrandId, (c, p) => new BrandDTO { BrandId = c.BrandId, BrandName = c.BrandName, LogoName = c.LogoName }).Distinct().ToList();
                CarBrands.Add(new BrandDTO { BrandId = -1, BrandName = "Все марки", LogoName = "all" });
                CarModels = Cars.CarModels.Join(Cars.Cars, c => c.ModelId, p => p.ModelId, (c, p) => new ModelDTO { ModelId = c.ModelId, ModelName = c.ModelName }).Distinct().ToList();
                CarModels.Add(new ModelDTO { ModelId = -1, ModelName = "Все модели" });
                minYear = Cars.Cars.OrderBy(c => c.IssueYar).First().IssueYar;
                minPrice = Cars.Cars.OrderBy(c => c.Price).First().Price;
                maxYear = Cars.Cars.OrderByDescending(c => c.IssueYar).First().IssueYar;
                maxPrice = Cars.Cars.OrderByDescending(c => c.Price).First().Price;
            }
            if ((CarsCount != _carsCount) && (_carsCount == 0))
            {
                CarsCount = _carsCount;
                CarBrands = new List<BrandDTO> { new BrandDTO { BrandId=-1, BrandName="Все марки", LogoName="all"} };
                CarModels = new List<ModelDTO> { new ModelDTO { ModelId = -1, ModelName = "Все модели"} }; 
                minYear = 1950;
                minPrice = 0;
                maxYear = DateTime.Now.Year;
                maxPrice = int.MaxValue;
            }

            f_minPrice = (int)minPrice;
            f_maxPrice = (int)maxPrice;
            f_minYear = minYear;
            f_maxYear = maxYear;
            f_brandId = -1;
            f_modelId = -1;
            //CarModels
        }
    }
}