using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdministadorDeTareasWeb.Startup))]
namespace AdministadorDeTareasWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
