using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MultipleFileUpload.Startup))]
namespace MultipleFileUpload
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
