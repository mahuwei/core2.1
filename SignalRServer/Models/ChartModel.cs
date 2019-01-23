using System;
using System.Collections.Generic;
using System.Threading;

namespace SignalRServer.Models {
    public class ChartModel {
        public ChartModel() {
            Data = new List<int>();
        }

        public List<int> Data { get; set; }
        public string Label { get; set; }
    }


    public class TimerManager {
        private readonly Action _action;
        private readonly Timer _timer;

        public TimerManager(Action action) {
            _action = action;
            var autoResetEvent = new AutoResetEvent(false);
            _timer = new Timer(Execute, autoResetEvent, 1000, 2000);
            TimerStarted = DateTime.Now;
        }

        public DateTime TimerStarted { get; }

        public void Execute(object stateInfo) {
            _action();

            if ((DateTime.Now - TimerStarted).Seconds > 60) _timer.Dispose();
        }
    }

    public static class DataManager {
        public static List<ChartModel> GetData() {
            var r = new Random();
            return new List<ChartModel> {
                new ChartModel {Data = new List<int> {r.Next(1, 40)}, Label = "Data1"},
                new ChartModel {Data = new List<int> {r.Next(1, 40)}, Label = "Data2"},
                new ChartModel {Data = new List<int> {r.Next(1, 40)}, Label = "Data3"},
                new ChartModel {Data = new List<int> {r.Next(1, 40)}, Label = "Data4"}
            };
        }
    }
}