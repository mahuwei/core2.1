using System.Collections.Generic;
using MediatR;

namespace MediatRTest.Commands.GetData {
    public class GetData : IRequest<List<string>> {
        public GetData(string data) {
            Data = data;
        }

        public string Data { get; set; }
    }
}