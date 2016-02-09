using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(sauemk.web.Startup))]
namespace sauemk.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
