using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_2BHLM.Startup))]
namespace _2BHLM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
