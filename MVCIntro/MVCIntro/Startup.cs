using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCIntro.Startup))]
namespace MVCIntro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
