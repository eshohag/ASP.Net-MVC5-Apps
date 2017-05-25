using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniversityRegistrationProcess.Startup))]
namespace UniversityRegistrationProcess
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
