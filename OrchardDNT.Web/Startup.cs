using Microsoft.Owin;
using OrchardDNT.Web.App_Start;
using Owin;

[assembly: OwinStartupAttribute(typeof(OrchardDNT.Web.Startup))]
namespace OrchardDNT.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
