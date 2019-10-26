using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRM2.Startup))]
namespace CRM2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
