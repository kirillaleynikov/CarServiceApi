using CarService.Services.Contracts.Models;

namespace CarService.Services.Contracts.Interface
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Получить список всех <see cref="EmployeeModel"/>
        /// </summary>
        Task<IEnumerable<EmployeeModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="EmployeeModel"/> по идентификатору
        /// </summary>
        Task<EmployeeModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<EmployeeModel> AddAsync(EmployeeModel model, CancellationToken cancellationToken);

        Task<EmployeeModel> EditAsync(EmployeeModel source, CancellationToken cancellationToken);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
