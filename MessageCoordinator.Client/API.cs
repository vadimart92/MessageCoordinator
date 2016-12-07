using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using ServiceStack.Messaging;
using ServiceStack.RabbitMq;

namespace MessageCoordinator.Client {
	public static class Api {
		public static IMessageCoordinatorClient CreateClient() {
			var connectionFactory = new ConnectionFactory {
					HostName = "localhost",
					Port = AmqpTcpEndpoint.UseDefaultPort
			};
			var messageFactory = new RabbitMqMessageFactory(connectionFactory);
			var client = messageFactory.CreateMessageQueueClient();
			return new MessageCoordinatorClient(client);
		}
	}
}
