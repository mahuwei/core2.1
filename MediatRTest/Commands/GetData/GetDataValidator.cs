using FluentValidation;

namespace MediatRTest.Commands.GetData {
    public class GetDataValidator : AbstractValidator<GetData> {
        public GetDataValidator() {
            RuleFor(d => d.Data).NotEmpty();
            RuleFor(d => d.Data).Length(2, 8);
        }
    }
}