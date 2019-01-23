using System;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using Microsoft.Extensions.Hosting;

namespace core2._1.test {
    public class BackgroundServiceTmp : IHostedService, IDisposable {
        private static readonly ILog Log =
            LogManager.GetLogger(Startup.Repository.Name, typeof(BackgroundService));


        private Timer _timer;

        public void Dispose() {
            _timer?.Dispose();
            Log.Info("Service Dispose.");
        }

        public Task StartAsync(CancellationToken cancellationToken) {
            Console.WriteLine("Service starting");
            Log.Info("Service starting");
            _timer = new Timer(Refresh, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) {
            Console.WriteLine("Service stopping");
            Log.Info("Service stopping");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        private void Refresh(object state) {
            Console.WriteLine(DateTime.Now.ToLongTimeString() +
                              ": Refresh Token!"); //在此写需要执行的任务

            Log.Info(DateTime.Now.ToLongTimeString() + ": Refresh Token!");
        }
    }
}
