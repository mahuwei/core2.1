using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace core2._1.test {
    public class BackgroundService : IHostedService, IDisposable {
        private Timer _timer;

        public void Dispose() {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken) {
            Console.WriteLine("Service starting");
            _timer = new Timer(Refresh, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) {
            Console.WriteLine("Service stopping");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        private void Refresh(object state) {
            Console.WriteLine(DateTime.Now.ToLongTimeString() +
                ": Refresh Token!"); //在此写需要执行的任务
        }
    }
}
