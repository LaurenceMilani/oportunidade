using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MinutoSeguros.UI.Startup))]
namespace MinutoSeguros.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
