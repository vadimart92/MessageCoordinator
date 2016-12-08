using System;
using System.Threading.Tasks;
using MessageCoordinator.DTO;
using ServiceStack.Messaging;

namespace MessageCoordinator.Client
{
	public interface IMessageCoordinatorClient : IDisposable {
		TResponseMessage Invoke<TMessage, TResponseMessage>(TMessage message) where TResponseMessage : BaseMessage where TMessage : BaseMessage;
	}

	public class MessageCoordinatorClient : IMessageCoordinatorClient {

		private readonly IMessageQueueClient _messageQueueClient;

		public MessageCoordinatorClient(IMessageQueueClient messageQueueClient) {
			_messageQueueClient = messageQueueClient;
		}

		public TResponseMessage Invoke<TMessage, TResponseMessage>(TMessage message) where TMessage : BaseMessage where TResponseMessage : BaseMessage {
			_messageQueueClient.Publish(new Message<TMessage>(message));
			IMessage<TResponseMessage> responseMsg = _messageQueueClient.Get<TResponseMessage>(QueueNames<TResponseMessage>.In);
			_messageQueueClient.Ack(responseMsg);
			return responseMsg.GetBody();
		}

		public void Dispose() {
			_messageQueueClient.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
