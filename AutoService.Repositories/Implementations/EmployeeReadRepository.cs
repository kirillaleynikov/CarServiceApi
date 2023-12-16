using CarService.Context.Contracts;
using CarService.Context.Contracts.Models;
using CarService.Repositories.Contracts;

namespace CarService.Repositories
{
    public class EmployeeReadRepository : IEmployeeReadRepository
    {
        private readonly ICarServiceContext context;

        public EmployeeReadRepository(ICarServiceContext context)
        {
            this.context = context;
        }

        Task<List<Employee>> IEmployeeReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => Task.FromResult(context.Employees.Where(x => x.DeletedAt == null)
                .OrderBy(x => x.Name)
                .ToList());

        Task<Employee?> IEmployeeReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => Task.FromResult(context.Employees.FirstOrDefault(x => x.Id == id));
    }
}
