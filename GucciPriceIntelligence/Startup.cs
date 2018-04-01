using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GucciPriceIntelligence.Startup))]
namespace GucciPriceIntelligence
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
