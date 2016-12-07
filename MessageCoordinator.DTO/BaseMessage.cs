using System;

namespace MessageCoordinator.DTO {
	public class BaseMessage {
		private Guid UId { get; set; }
		public Version Version { get; set; }
	}
}