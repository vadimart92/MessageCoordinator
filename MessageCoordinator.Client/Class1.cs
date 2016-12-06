using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageCoordinator.Client
{

	public class Message {
		public Guid UId;
		public string Name { get; set; }
		public string Payload { get; set; }
	}

    public class MessageCoordinatorClient
    {
		public void Push() {

		}
    }
}
