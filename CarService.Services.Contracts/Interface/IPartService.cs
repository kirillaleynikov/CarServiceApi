using CarService.Services.Contracts.Models;

namespace CarService.Services.Contracts.Interface
{
    public interface IPartService
    {
        /// <summary>
        /// Получить список всех <see cref="PartModel"/>
        /// </summary>
        Task<IEnumerable<PartModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="PartModel"/> по идентификатору
        /// </summary>
        Task<PartModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
