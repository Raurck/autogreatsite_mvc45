using System.Data.Entity;
using System;
using System.Linq;

namespace autogreatsite_mvc45.Models
{
    public class SampleCars
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            var context = new CarContext();
            if (context == null)
            {
                return;
            }
                
            if (context.Database.Exists())
            {
                if (!context.Car.Any())
                {
                    var nissan = context.Brand.Add(new Brand { BrandId = 1,BrandName="Nissan", Cars = null }  );
                    var mitsu = context.Brand.Add(new Brand { BrandId = 2, BrandName = "Mitsubishi", Cars = null });


                    context.Car.Add(new Car { Model = "машина 1", CarBrand = nissan, BrandId = nissan.BrandId });
                    context.Car.Add(new Car { Model = "машина 2", CarBrand = nissan, BrandId = nissan.BrandId });
                    context.Car.Add(new Car { Model = "машина 3", CarBrand = nissan, BrandId = nissan.BrandId });
                    context.Car.Add(new Car { Model = "машина 4", CarBrand = nissan, BrandId = nissan.BrandId });
                    context.Car.Add(new Car { Model = "машина 5", CarBrand = mitsu, BrandId = mitsu.BrandId });
                    context.Car.Add(new Car { Model = "машина 6", CarBrand = mitsu, BrandId = mitsu.BrandId });
                    context.Car.Add(new Car { Model = "машина 7", CarBrand = mitsu, BrandId = mitsu.BrandId });
                    context.Car.Add(new Car { Model = "машина 8", CarBrand = mitsu, BrandId = mitsu.BrandId });
                }
            }
        }
    }
}
