using System.Data.Entity;
using System;
using System.Linq;

namespace autogreatsite_mvc45.Models
{
    public class SampleCars
    {
        public static async void Initialize(IServiceProvider serviceProvider)
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
                    await context.SaveChangesAsync();
                }
                if (!context.Brands.Any())
                {

                    context.Drives.Add(new Drive { DriveID = 1, Name = "передний" });
                    context.Drives.Add(new Drive { DriveID = 2, Name = "задний" });
                    context.Drives.Add(new Drive { DriveID = 3, Name = "полный" });
                    await context.SaveChangesAsync();
                }
                if (!context.Brands.Any())
                {

                    context.Rudders.Add(new Rudder { RudderID = 1, Name = "левый" });
                    context.Rudders.Add(new Rudder { RudderID = 2, Name = "правый" });
                    await context.SaveChangesAsync();
                }
                if (!context.Brands.Any())
                {

                    context.Transmissions.Add(new Transmission { TransmissionID = 1, Name = "АКПП" });
                    context.Transmissions.Add(new Transmission { TransmissionID = 2, Name = "МКПП" });
                    context.Transmissions.Add(new Transmission { TransmissionID = 3, Name = "CVT" });
                    await context.SaveChangesAsync();
                }
                if (!context.Brands.Any())
                {
                   //var nissan = context.Brands.Add(new Brand { BrandId = 1, BrandName = "Nissan", Cars = null });
                    //var mitsu = context.Brands.Add(new Brand { BrandId = 2, BrandName = "Mitsubishi", Cars = null });

                    context.Brands.Add(new Brand { BrandName = "Alfa-Romeo"});
                    context.Brands.Add(new Brand {  BrandName = "Audi"});
                    context.Brands.Add(new Brand {  BrandName = "Bmw"});
                    context.Brands.Add(new Brand {  BrandName = "Chaevrolet"});
                    context.Brands.Add(new Brand {  BrandName = "Citroen"});
                    context.Brands.Add(new Brand {  BrandName = "Ferrari"});
                    context.Brands.Add(new Brand {  BrandName = "Fiat"});
                    context.Brands.Add(new Brand {  BrandName = "Ford"});
                    context.Brands.Add(new Brand {  BrandName = "Geely"});
                    context.Brands.Add(new Brand {  BrandName = "Greatwall"});
                    context.Brands.Add(new Brand {  BrandName = "Honda"});
                    context.Brands.Add(new Brand {  BrandName = "Hyundai"});
                    context.Brands.Add(new Brand {  BrandName = "Infiniti"});
                    context.Brands.Add(new Brand {  BrandName = "Jaguar"});
                    context.Brands.Add(new Brand {  BrandName = "Jeep"});
                    context.Brands.Add(new Brand {  BrandName = "Kia"});
                    context.Brands.Add(new Brand {  BrandName = "Lancia"});
                    context.Brands.Add(new Brand {  BrandName = "Land - rover"});
                    context.Brands.Add(new Brand {  BrandName = "Lexus"});
                    context.Brands.Add(new Brand {  BrandName = "Lifan"});
                    context.Brands.Add(new Brand {  BrandName = "Mazda"});
                    context.Brands.Add(new Brand {  BrandName = "Mercedes"});
                    context.Brands.Add(new Brand {  BrandName = "Mgcars"});
                    context.Brands.Add(new Brand {  BrandName = "Mini"});
                    //context.Brands.Add(new Brand {  BrandName = "Mitsubishi"});
                   // context.Brands.Add(new Brand {  BrandName = "Nissan"});
                    context.Brands.Add(new Brand {  BrandName = "Opel"});
                    context.Brands.Add(new Brand {  BrandName = "Peugeot"});
                    context.Brands.Add(new Brand {  BrandName = "Porsche"});
                    context.Brands.Add(new Brand {  BrandName = "Renault"});
                    context.Brands.Add(new Brand {  BrandName = "Seat"});
                    context.Brands.Add(new Brand {  BrandName = "Skoda"});
                    context.Brands.Add(new Brand {  BrandName = "Ssangyong"});
                    context.Brands.Add(new Brand {  BrandName = "Subaru"});
                    context.Brands.Add(new Brand {  BrandName = "Toyota"});
                    context.Brands.Add(new Brand {  BrandName = "Volvo"});
                    context.Brands.Add(new Brand {  BrandName = "Volkswagen", LogoName = "vw"});
                    context.Brands.Add(new Brand {  BrandName = "ВАЗ", LogoName = "autovaz" });
                    await context.SaveChangesAsync();
                }
                if (!context.Cars.Any())
                {

                }
            }
        }
    }
}
