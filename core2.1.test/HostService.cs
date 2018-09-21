using System;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using Microsoft.Extensions.Hosting;

namespace core2._1.test {
    public class HostService : BackgroundService {
        private static readonly ILog Log =
            LogManager.GetLogger(Startup.Repository.Name, typeof(HostService));

        //private Timer _timer;

        //public override void Dispose() {
        //    _timer?.Dispose();
        //    Log.Info("HostService Dispose.");
        //}

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
            Log.Info("Service starting");

            while (!stoppingToken.IsCancellationRequested) {
                Log.Info(DateTime.Now.ToLongTimeString() +
                         ": Refresh Token!"); //在此写需要执行的任务
                await Task.Delay(5000, stoppingToken);
            }

            Log.Info("Service stopping");
        }

        //public override Task StartAsync(CancellationToken cancellationToken) {
        //    Log.Info("HostService starting");
        //    _timer = new Timer(Refresh, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        //    return Task.CompletedTask;
        //}

        //public override Task StopAsync(CancellationToken cancellationToken) {
        //    Log.Info("HostService stopping");
        //    _timer?.Change(Timeout.Infinite, 0);
        //    return Task.CompletedTask;
        //}

        //private void Refresh(object state) {
        //    Log.Info(DateTime.Now.ToLongTimeString() + ": HostService Refresh Token!");
        //}
    }
}
