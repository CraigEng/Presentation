using BabyRegisterWeb;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof (Startup))]
namespace BabyRegisterWeb
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}