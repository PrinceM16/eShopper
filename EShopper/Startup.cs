using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EShopper.Startup))]
namespace EShopper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
