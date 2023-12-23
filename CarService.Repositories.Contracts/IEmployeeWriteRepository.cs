using CarService.Context.Contracts.Models;

namespace CarService.Repositories.Contracts
{
    /// <summary>
    /// Репозиторий записи <see cref="Employee"/>
    /// </summary>
    public interface IEmployeeWriteRepository : IRepositoryWriter<Employee>
    {
    }
}
