using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WedLab345.Startup))]
namespace WedLab345
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
