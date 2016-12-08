using MessageCoordinator.Client;
using MessageCoordinator.DTO;
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
			ReadRecordsCountResultMessage result;
			using (var client = Api.CreateClient()) {
				var msg = new ReadRecordsCountMessage {
					Version = GetType().Assembly.GetName().Version,
					SchemaName = request.Message
				};
				result = client.Invoke<ReadRecordsCountMessage, ReadRecordsCountResultMessage>(msg);
			}
			var context = GlobalHost.ConnectionManager.GetHubContext<CloudServicesHub>();
			context.Clients.All.UpdateResults(result.Count);
			return new UpdateResponse {Success = true};
		}
	}

}