using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Spartane.Web.Startup))]
namespace Spartane.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureCkFinder(app);
        }
    }
}
