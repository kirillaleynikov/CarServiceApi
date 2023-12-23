using CarService.Services.Contracts.Models;

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
    }
}
