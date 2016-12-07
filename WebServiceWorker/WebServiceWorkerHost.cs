using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Funq;
using ServiceStack;

namespace WebServiceWorker {
	public class WebServiceWorkerHost: AppSelfHostBase {
		public WebServiceWorkerHost(params Assembly[] assembliesWithServices) : base("WebServiceWorkerHost", assembliesWithServices) {
		}

		public override void Configure(Container container) {
			
		}
	}
}
