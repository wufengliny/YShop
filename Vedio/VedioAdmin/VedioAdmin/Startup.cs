using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VedioAdmin.Startup))]
namespace VedioAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
