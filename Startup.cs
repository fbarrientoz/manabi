using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(manabi.Startup))]
namespace manabi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
