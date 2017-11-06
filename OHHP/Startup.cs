using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OHHP.Startup))]
namespace OHHP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
