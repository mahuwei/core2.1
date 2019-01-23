using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRServer.Models;

namespace SignalRServer.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase {
        private readonly IHubContext<ChartHub> _hub;

        public ChartController(IHubContext<ChartHub> hub) {
            _hub = hub;
        }

        public IActionResult Get() {
            var timerManager = new TimerManager(() =>
                _hub.Clients.All.SendAsync("transferchartdata", DataManager.GetData()));

            return Ok(new {Message = "Request Completed"});
        }
    }
}