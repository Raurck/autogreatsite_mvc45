using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace autogreatsite_mvc45.Models
{
    public class CarContext: DbContext
    {
        public DbSet<Car> Car { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Body> Body { get; set; }
        public DbSet<Drive> Drive { get; set; }
        public DbSet<Engine> Engine { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<Rudder> Rudder { get; set; }
        public DbSet<Transmission> Transmission { get; set; }

    }
}
