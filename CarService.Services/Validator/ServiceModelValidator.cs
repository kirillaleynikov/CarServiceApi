using CarService.Services.Contracts.Models;
using FluentValidation;

namespace CarService.Services.Validator
{
    public class ServiceModelValidator : AbstractValidator<ServiceModel>
    {
        public ServiceModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(MessageForValidation.DefaultMessage)
                .NotNull().WithMessage(MessageForValidation.DefaultMessage)
                .Length(2, 40).WithMessage(MessageForValidation.LengthMessage);

            RuleFor(x => x.Price)
                .InclusiveBetween(100, 5000).WithMessage(MessageForValidation.InclusiveBetweenMessage);

        }
    }
}
