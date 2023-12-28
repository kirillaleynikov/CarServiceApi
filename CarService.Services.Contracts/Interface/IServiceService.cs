using CarService.Services.Contracts.Models;
using CarService.Services.Contracts.ModelsRequest;

namespace CarService.Services.Contracts.Interface
{
    public interface IServiceService
    {
        /// <summary>
        /// Получить список всех <see cref="ServiceModel"/>
        /// </summary>
        Task<IEnumerable<ServiceModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="ServiceModel"/> по идентификатору
        /// </summary>
        Task<ServiceModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет новый ремонт
        /// </summary>
        Task<ServiceModel> AddAsync(ServiceRequestModel serviceRequestModel, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует существующее расписание
        /// </summary>
        Task<ServiceModel> EditAsync(ServiceRequestModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующее расписание
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
