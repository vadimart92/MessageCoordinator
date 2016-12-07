using System;

namespace WebServiceWorker {
	class Program {
		static void Main(string[] args) {
			using (var host = new WebServiceWorkerHost(typeof(DataService).Assembly).Init()) {
				host.Start("http://localhost:8000/");
				Console.WriteLine("Started...");
				Console.ReadKey();
			}
		}
	}
}
