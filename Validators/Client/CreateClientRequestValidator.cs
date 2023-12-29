using FluentValidation;
using CarService.Api.ModelsRequest.Client;

namespace CarService.Api.Validators.Client
{
    /// <summary>
    /// Валидатор класса <see cref="CreateClientRequest"/>
    /// </summary>
    public class CreateEmployeeRequestValidator : AbstractValidator<CreateClientRequest>
    {
        /// <summary>
        /// Инициализирую <see cref="CreateEmployeeRequestValidator"/>
        /// </summary>
        public CreateEmployeeRequestValidator()
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
