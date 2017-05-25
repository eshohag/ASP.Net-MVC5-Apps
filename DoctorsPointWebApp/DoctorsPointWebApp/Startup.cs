using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoctorsPointWebApp.Startup))]
namespace DoctorsPointWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
