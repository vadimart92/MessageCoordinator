using MessageCoordinator.DTO;
using ServiceStack;

namespace MessageCoordinator {
	public class HeartbeatRespose {
		public bool Ok { get; set; }
	}
	public class HeartbeatRequest : IReturn<HeartbeatRespose> {}

	public class HeartbeatService: Service {
		public object All(HeartbeatRequest request) {
			return new HeartbeatRespose() {
				Ok = true
			};
		}
	}

	public class MsgService : Service {
		public object All(ReadRecordsCountMessage message) {
			return new ReadRecordsCountResultMessage {
				Count = message.SchemaName.Length
			};
		} 
	}
}
