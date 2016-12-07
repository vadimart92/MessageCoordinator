using MessageCoordinator.Client;
using MessageCoordinator.DTO;
using Microsoft.AspNet.SignalR;

namespace WebUI.Hubs {
	public class CloudServicesHub : Hub<ICloudServicesClient> {
		public void CallWebService(string schema) {
			var client = Api.CreateClient();
			var msg = new ReadRecordsCountMessage {
				Version = GetType().Assembly.GetName().Version,
				SchemaName = schema
			};
			var result = client.Invoke<ReadRecordsCountMessage, ReadRecordsCountResultMessage>(msg);
			var context = GlobalHost.ConnectionManager.GetHubContext<CloudServicesHub>();
			context.Clients.All.UpdateResults(result.Count);
		}
	}

	public interface ICloudServicesClient {
		void UpdateResults(string results);
	}
}