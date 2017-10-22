using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(woodenitems.Startup))]
namespace woodenitems
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
