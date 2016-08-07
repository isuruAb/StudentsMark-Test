using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcGeekAcademy.Startup))]
namespace MvcGeekAcademy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
