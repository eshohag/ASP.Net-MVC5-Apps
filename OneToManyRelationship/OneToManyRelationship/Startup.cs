using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OneToManyRelationship.Startup))]
namespace OneToManyRelationship
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
