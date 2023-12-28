using CarService.Context.Contracts.Models;

namespace CarService.Repositories.Contracts
{
    /// <summary>
    /// Репозиторий чтения <see cref="Service"/>
    /// </summary>
    public interface IServiceReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="Service"/>
        /// </summary>
        Task<IReadOnlyCollection<Service>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Service"/> по идентификатору
        /// </summary>
        Task<Service?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Проверка есть ли <see cref="Service"/> по указанному id
        /// </summary>
        Task<bool> AnyByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить список <see cref="Service"/> по идентификаторам
        /// </summary>
        Task<Dictionary<Guid, Service>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellation);
    }
}
