using CarService.Services.Contracts.Models;

namespace CarService.Services.Contracts.Interface
{
    public interface IRepairService
    {
        /// <summary>
        /// Получить список всех <see cref="RepairModel"/>
        /// </summary>
        Task<IEnumerable<RepairModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="RepairModel"/> по идентификатору
        /// </summary>
        Task<RepairModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
