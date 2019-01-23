using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatRTest.Commands.GetData {
    public class GetDataHandler : IRequestHandler<GetData, List<string>> {
        public Task<List<string>> Handle(GetData request, CancellationToken cancellationToken) {
            var ls = new List<string>();
            for (var i = 0; i < 5; i++) ls.Add($"{request.Data} - {i + 1}");

            return Task.FromResult(ls);
        }
    }
}