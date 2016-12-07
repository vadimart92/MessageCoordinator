using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Funq;
using MessageCoordinator.DTO;
using RabbitMQ.Client;
using ServiceStack;
using ServiceStack.Host;
using ServiceStack.Messaging;
using ServiceStack.RabbitMq;
using ServiceStack.Web;

namespace MessageCoordinator {
	class Program {
		static void Main(string[] args) {
			using (var app = new MsgHost(typeof(HeartbeatService).Assembly).Init()) {
				app.Start("http://localhost:8001/");
				Console.WriteLine(app.Container.Resolve<IMessageService>().GetStatus());
				Console.ReadKey();
			}
		}
	}
	public class MsgHost : AppSelfHostBase {
		public MsgHost(params Assembly[] assembliesWithServices) : base("Coordinator", assembliesWithServices) {}

		public MsgHost(string serviceName, string handlerPath, params Assembly[] assembliesWithServices) : base(serviceName, handlerPath, assembliesWithServices) {}

		public override void Configure(Container container) {
			container.Register<IMessageService>(c => {
				ConnectionFactory connectionFactory = new ConnectionFactory() {
					HostName = "localhost"
				};
				return new RabbitMqServer(new RabbitMqMessageFactory(connectionFactory));
			});
			var messageService = container.Resolve<IMessageService>();
			messageService.RegisterHandler<ReadRecordsCountMessage>(message => {
				object resultMessage = new ReadRecordsCountResultMessage {
					Count = message.GetBody().SchemaName.Length
				};
				message.Options = (int)MessageOption.NotifyOneWay;
				return resultMessage;
			});
			messageService.Start();
		}
	}
}
