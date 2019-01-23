using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MediatRTest.PipelineBehaviors {
    public class
        RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest
            , TResponse> {
        private readonly ILogger<TRequest> _logger;
        private readonly Stopwatch _timer;

        public RequestPerformanceBehaviour(ILogger<TRequest> logger) {
            _timer = new Stopwatch();
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next) {
            _timer.Start();
            var response = await next();
            _timer.Stop();

            if (_timer.ElapsedMilliseconds <= 500) return response;
            var name = typeof(TRequest).Name;
            _logger.LogWarning(
                "运行时间太长, Request: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}",
                name, _timer.ElapsedMilliseconds, request);
            return response;
        }
    }
}
