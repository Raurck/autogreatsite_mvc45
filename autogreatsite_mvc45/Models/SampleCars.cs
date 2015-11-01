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
                if (!context.Brands.Any())
                {
                    context.Bodys.Add(new Body { BodyID = 1, Name = "седан" });
                    context.Bodys.Add(new Body { BodyID = 2, Name = "хэчбэк" });
                    context.Bodys.Add(new Body { BodyID = 3, Name = "универсал" });
                    context.Bodys.Add(new Body { BodyID = 4, Name = "SUV" });
                    context.Bodys.Add(new Body { BodyID = 5, Name = "пикап" });
                    context.Bodys.Add(new Body { BodyID = 6, Name = "внедорожник" });
                    context.Bodys.Add(new Body { BodyID = 7, Name = "кроссовер" });
                    context.Bodys.Add(new Body { BodyID = 8, Name = "родстер" });
                    context.Bodys.Add(new Body { BodyID = 9, Name = "кабриолет" });
                    context.Bodys.Add(new Body { BodyID = 10, Name = "купе" });
                    context.Bodys.Add(new Body { BodyID = 11, Name = "минвэн" });
                    context.Bodys.Add(new Body { BodyID = 12, Name = "лимузин" });
                    context.SaveChangesAsync();
                }
                if (!context.Brands.Any())
                {

                    context.Drives.Add(new Drive { DriveID = 1, Name = "передний" });
                    context.Drives.Add(new Drive { DriveID = 2, Name = "задний" });
                    context.Drives.Add(new Drive { DriveID = 3, Name = "полный" });
                    context.SaveChangesAsync();
                }
                if (!context.Brands.Any())
                {

                    context.Rudders.Add(new Rudder { RudderID = 1, Name = "левый" });
                    context.Rudders.Add(new Rudder { RudderID = 2, Name = "правый" });
                    context.SaveChangesAsync();
                }
                if (!context.Brands.Any())
                {

                    context.Transmissions.Add(new Transmission { TransmissionID = 1, Name = "АКПП" });
                    context.Transmissions.Add(new Transmission { TransmissionID = 2, Name = "МКПП" });
                    context.Transmissions.Add(new Transmission { TransmissionID = 3, Name = "CVT" });
                    context.SaveChangesAsync();
                }
                if (!context.Brands.Any())
                {
                   var nissan = context.Brands.Add(new Brand { BrandId = 1, BrandName = "Nissan", Cars = null });
                    var mitsu = context.Brands.Add(new Brand { BrandId = 2, BrandName = "Mitsubishi", Cars = null });

                    context.Brands.Add(new Brand { BrandName = "Alfa-Romeo",Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Audi", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Bmw", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Chaevrolet", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Citroen", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Ferrari", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Fiat", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Ford", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Geely", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Greatwall", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Honda", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Hyundai", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Infiniti", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Jaguar", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Jeep", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Kia", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Lancia", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Land - rover", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Lexus", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Lifan", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Mazda", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Mercedes", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Mgcars", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Mini", Cars = null});
                    //context.Brands.Add(new Brand {  BrandName = "Mitsubishi", Cars = null});
                   // context.Brands.Add(new Brand {  BrandName = "Nissan", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Opel", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Peugeot", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Porsche", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Renault", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Seat", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Skoda", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Ssangyong", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Subaru", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Toyota", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Volvo", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "Volkswagen", LogoName = "vw", Cars = null});
                    context.Brands.Add(new Brand {  BrandName = "ВАЗ", LogoName = "autovaz", Cars = null });
                    context.SaveChangesAsync();
                }
                if (!context.Cars.Any())
                {
                    var rnd = new Random();
                    for (int i = 0; i< 15; i++)
                    {
                        var nissan = context.Brands.SingleOrDefault(x=>x.BrandName=="Nissan");// .Add(new Brand { BrandId = 1, BrandName = "Nissan", Cars = null });
                        var mitsu = context.Brands.SingleOrDefault(x => x.BrandName == "Mitsubishi");

                        context.Cars.Add(new Car { ModelId = 0, BrandId = (i%2==0?mitsu.BrandId:nissan.BrandId), DriveId = 1, RudderId = 1, BodyId = 1, TransmissionId = 1, IssueYar = rnd.Next(2000, 2014), DistanceTraveled = rnd.Next(5, 100) * 1000, Price = rnd.Next(50, 900) * 1000 ,CarColor="Другой",Description="Тестовая запись"});
                    }
                    context.SaveChangesAsync();
                }
            }
        }
    }
}
