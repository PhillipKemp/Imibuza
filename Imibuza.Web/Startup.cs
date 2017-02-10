using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Imibuza.Web.Startup))]
namespace Imibuza.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
