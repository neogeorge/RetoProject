using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Reto.Backend.Startup))]
namespace Reto.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
