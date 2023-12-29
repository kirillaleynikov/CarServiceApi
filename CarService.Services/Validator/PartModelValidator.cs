using CarService.Services.Contracts.Models;
using FluentValidation;

namespace CarService.Services.Validator
{
    public class PartModelValidator : AbstractValidator<PartModel>
    {
        public PartModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(MessageForValidation.DefaultMessage)
                .NotNull().WithMessage(MessageForValidation.DefaultMessage)
                .Length(2, 40).WithMessage(MessageForValidation.LengthMessage);

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage(MessageForValidation.DefaultMessage)
                .NotNull().WithMessage(MessageForValidation.DefaultMessage);

            RuleFor(x => x.Auto)
                .NotEmpty().WithMessage(MessageForValidation.DefaultMessage)
                .NotNull().WithMessage(MessageForValidation.DefaultMessage)
                .Length(9, 9).WithMessage(MessageForValidation.LengthMessage);

            RuleFor(x => x.Country)
                .NotEmpty().WithMessage(MessageForValidation.DefaultMessage)
                .NotNull().WithMessage(MessageForValidation.DefaultMessage)
                .Length(9, 9).WithMessage(MessageForValidation.LengthMessage);

        }
    }
}
