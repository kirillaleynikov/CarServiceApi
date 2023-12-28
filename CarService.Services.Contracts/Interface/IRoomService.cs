using CarService.Services.Contracts.Models;
using CarService.Services.Contracts.ModelsRequest;

namespace CarService.Services.Contracts.Interface
{
    public interface IRoomService
    {
        /// <summary>
        /// Получить список всех <see cref="RoomModel"/>
        /// </summary>
        Task<IEnumerable<RoomModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="RoomModel"/> по идентификатору
        /// </summary>
        Task<RoomModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет новый ремонт
        /// </summary>
        Task<RoomModel> AddAsync(RoomRequestModel roomRequestModel, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует существующее расписание
        /// </summary>
        Task<RoomModel> EditAsync(RoomRequestModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующее расписание
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
