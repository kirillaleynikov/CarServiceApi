using CarService.Repositories.Contracts;
using CarService.Services.Contracts;
using CarService.Services.Contracts.Models;

namespace CarService.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeReadRepository employeeReadRepository;

        public EmployeeService(IEmployeeReadRepository employeeReadRepository)
        {
            this.employeeReadRepository = employeeReadRepository;
        }

        async Task<IEnumerable<EmployeeModel>> IEmployeeService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await employeeReadRepository.GetAllAsync(cancellationToken);
            return result.Select(x => new EmployeeModel
            {
                Id = x.Id,
                Name = x.Name,
                DateOfBirth = x.DateOfBirth,
                PhoneNumber = x.PhoneNumber,
            });
        }

        async Task<EmployeeModel?> IEmployeeService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await employeeReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                return null;
            }

            return new EmployeeModel
            {
                Id = item.Id,
                Name = item.Name,
                DateOfBirth = item.DateOfBirth,
                PhoneNumber = item.PhoneNumber,
            };
        }
    }
}
