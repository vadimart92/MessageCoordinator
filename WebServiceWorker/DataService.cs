using ServiceStack;

namespace WebServiceWorker {

	public class Activity {
		public string Title { get; set; }
	}
	[Route("/activities")]
	public class ActivityRequest : IReturn<Activity> {
		public string Title { get; set; }
	}

	public class DataService : Service {
		public object Get(ActivityRequest activityRequest) {
			return new Activity {
				Title = activityRequest.Title
			};
		}
	}
}
