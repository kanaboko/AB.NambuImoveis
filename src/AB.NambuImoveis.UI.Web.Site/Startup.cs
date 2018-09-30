using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AB.NambuImoveis.UI.Web.Site.Startup))]
namespace AB.NambuImoveis.UI.Web.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
