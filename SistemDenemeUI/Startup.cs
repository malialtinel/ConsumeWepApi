using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemDenemeUI.Startup))]
namespace SistemDenemeUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
