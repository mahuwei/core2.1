﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRServer.Models {
    public class ChartHub : Hub {
        public Task SendMessage(string user, string message) {
            return Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}