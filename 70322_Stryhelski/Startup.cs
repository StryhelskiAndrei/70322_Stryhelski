using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_70322_Stryhelski.Startup))]
namespace _70322_Stryhelski
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
