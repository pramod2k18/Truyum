using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TruYumFinal.Startup))]
namespace TruYumFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
