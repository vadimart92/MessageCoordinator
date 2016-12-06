using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebUI.Startup))]
namespace WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
			app.UseErrorPage();
			app.Map("/signalr", map => {
				var config = new HubConfiguration();
				map.UseCors(CorsOptions.AllowAll)
				   .RunSignalR(config);
			});

		}
	}
}
