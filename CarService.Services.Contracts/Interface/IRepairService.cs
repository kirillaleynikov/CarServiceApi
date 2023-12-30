using CarService.Services.Contracts.Models;
using CarService.Services.Contracts.ModelsRequest;

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

        /// <summary>
        /// Добавляет новый ремонт
        /// </summary>
        Task<RepairModel> AddAsync(RepairRequestModel model, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует существующее расписание
        /// </summary>
        Task<RepairModel> EditAsync(RepairRequestModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующее расписание
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
