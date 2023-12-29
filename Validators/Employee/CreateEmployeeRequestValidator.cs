using FluentValidation;
using CarService.Api.ModelsRequest.Employee;

namespace CarService.Api.Validators.Employee
{
    /// <summary>
    /// Валидатор класса <see cref="CreateEmployeeRequest"/>
    /// </summary>
    public class CreateEmployeeRequestValidator : AbstractValidator<CreateEmployeeRequest>
    {
        /// <summary>
        /// Инициализирую <see cref="CreateEmployeeRequestValidator"/>
        /// </summary>
        public CreateEmployeeRequestValidator()
        {
            RuleFor(employee => employee.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Имя не должно быть пустым или null");
        }
    }
}
