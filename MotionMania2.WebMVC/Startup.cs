using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MotionMania2.WebMVC.Startup))]
namespace MotionMania2.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
