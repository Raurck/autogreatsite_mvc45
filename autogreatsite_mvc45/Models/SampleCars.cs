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
                }
                if (!context.Brands.Any())
                {

                    context.Drives.Add(new Drive { DriveID = 1, Name = "пердний" });
                    context.Drives.Add(new Drive { DriveID = 2, Name = "задний" });
                    context.Drives.Add(new Drive { DriveID = 3, Name = "полный" });
                }
                if (!context.Brands.Any())
                {

                    context.Rudders.Add(new Rudder { RudderID = 1, Name = "левый" });
                    context.Rudders.Add(new Rudder { RudderID = 2, Name = "правый" });
                }
                if (!context.Brands.Any())
                {

                    context.Transmissions.Add(new Transmission { TransmissionID = 1, Name = "АКПП" });
                    context.Transmissions.Add(new Transmission { TransmissionID = 2, Name = "МКПП" });
                    context.Transmissions.Add(new Transmission { TransmissionID = 3, Name = "CVT" });
                }
                if (!context.Brands.Any())
                {
                    var nissan = context.Brands.Add(new Brand { BrandId = 1, BrandName = "Nissan", Cars = null });
                    var mitsu = context.Brands.Add(new Brand { BrandId = 2, BrandName = "Mitsubishi", Cars = null });
                }
                if (!context.Cars.Any())
                {
                    var rnd = new Random();
                    for (int i = 0; i< 15; i++)
                    {
                        var nissan = context.Brands.SingleOrDefault(x=>x.BrandName=="Nissan");// .Add(new Brand { BrandId = 1, BrandName = "Nissan", Cars = null });
                        var mitsu = context.Brands.SingleOrDefault(x => x.BrandName == "Mitsubishi");

                        context.Cars.Add(new Car { Model = String.Format("машина {0}", i), BrandId = (i%2==0?mitsu.BrandId:nissan.BrandId), DriveId = 1, RudderId = 1, BodyId = 1, TransmissionId = 1, IssueYar = rnd.Next(2000, 2014), DistanceTraveled = rnd.Next(5, 100) * 1000, Price = rnd.Next(50, 900) * 1000 ,CarColor="Другой",Description="Тестовая запись"});
                    }
                    context.SaveChangesAsync();
                }
            }
        }
    }
}
