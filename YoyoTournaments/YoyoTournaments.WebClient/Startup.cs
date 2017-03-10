using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YoyoTournaments.WebClient.Startup))]
namespace YoyoTournaments.WebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
