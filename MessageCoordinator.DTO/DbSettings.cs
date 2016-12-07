using System.Collections.Generic;

namespace MessageCoordinator.DTO {
	public class DbSettings {
		public string MasterDbConnectionString { get; set; }
		public List<string> SlaveDbConnectionStringList { get; set; }
	}
}