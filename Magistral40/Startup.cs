using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Magistral40.Startup))]
namespace Magistral40
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
