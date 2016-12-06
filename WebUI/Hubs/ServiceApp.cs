using System.Reflection;
using Funq;
using ServiceStack;

namespace WebUI.Hubs {
	public class ServiceAppHost: AppHostBase
	{
		public ServiceAppHost(params Assembly[] assembliesWithServices) : base("Cloud coordinator endpoint", assembliesWithServices) {
			
		}

		public override void Configure(Container container) {
			SetConfig(new HostConfig { HandlerFactoryPath = "api" });
		}
	}
}