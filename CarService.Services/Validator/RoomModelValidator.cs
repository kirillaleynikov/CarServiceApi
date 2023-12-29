using CarService.Services.Contracts.Models;
using FluentValidation;

namespace CarService.Services.Validator
{
    public class RoomModelValidator : AbstractValidator<RoomModel>
    {
        public RoomModelValidator()
        {
            RuleFor(x => x.Number)
                .NotEmpty().WithMessage(MessageForValidation.DefaultMessage)
                .NotNull().WithMessage(MessageForValidation.DefaultMessage)
                .Length(2, 40).WithMessage(MessageForValidation.LengthMessage);

            RuleFor(x => x.Square)
                .NotEmpty().WithMessage(MessageForValidation.DefaultMessage)
                .NotNull().WithMessage(MessageForValidation.DefaultMessage);

        }
    }
}
