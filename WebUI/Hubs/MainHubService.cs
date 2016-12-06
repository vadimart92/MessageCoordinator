using Microsoft.AspNet.SignalR;
using ServiceStack;

namespace WebUI.Hubs {
	[Route("/update/{Message}")]
	public class Update {
		public string Message {
			get; set;
		}
	}

	public class UpdateResponse {
		public bool Success { get; set; }
	}

	public class MainHubService : Service {
		public object Any(Update request) {
			var context = GlobalHost.ConnectionManager.GetHubContext<CloudServicesHub>();
			context.Clients.All.UpdateResults(request.Message);
			return new UpdateResponse {Success = true};
		}
	}

}