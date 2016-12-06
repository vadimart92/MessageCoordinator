using Microsoft.AspNet.SignalR;

namespace WebUI.Hubs {
	public class CloudServicesHub : Hub<ICloudServicesClient> {
		public void CallWebService(int number) {
			Clients.Caller.UpdateResults(number.ToString());
		}
	}

	public interface ICloudServicesClient {
		void UpdateResults(string results);
	}
}