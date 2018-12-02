using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BrasletsWeb.Startup))]
namespace BrasletsWeb
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}