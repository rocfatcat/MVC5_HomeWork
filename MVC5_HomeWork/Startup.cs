using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5_HomeWork.Startup))]
namespace MVC5_HomeWork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
