using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace autogreatsite_mvc45.Models
{
    public class CarContext: DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Body> Bodys { get; set; }
        public DbSet<Drive> Drives { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Rudder> Rudders { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }

        public CarContext() : base("DefaultConnection")
        {
        }
    }
}
