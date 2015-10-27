using autogreatsite_mvc45.Models;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(autogreatsite_mvc45.Startup))]
namespace autogreatsite_mvc45
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            SampleCars.Initialize(null);
            
        }
    }
}
