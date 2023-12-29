using FluentValidation;
using CarService.Api.ModelsRequest.Employee;

namespace CarService.Api.Validators.Employee
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeRequestValidator : AbstractValidator<EmployeeRequest>
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
        }
    }
}
