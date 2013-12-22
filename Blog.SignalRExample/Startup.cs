using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Blog.SignalRExample.App_Start.Startup))]
namespace Blog.SignalRExample.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
