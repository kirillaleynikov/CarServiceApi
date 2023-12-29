using FluentValidation;
using CarService.Api.ModelsRequest.Client;

namespace CarService.Api.Validators.Client
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeRequestValidator : AbstractValidator<ClientRequest>
    {
        /// <summary>
        /// ctor
        /// </summary>
        public EmployeeRequestValidator()
        {
            RuleFor(client => client.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Имя не должно быть пустым или null");

            RuleFor(client => client.DateOfBirth)
                .NotNull()
                .NotEmpty()
                .WithMessage("Дата рождения не должна быть пустым или null");

        }
    }
}
