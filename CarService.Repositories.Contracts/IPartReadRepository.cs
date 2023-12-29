using CarService.Context.Contracts.Models;

namespace CarService.Repositories.Contracts
{
    /// <summary>
    /// Репозиторий чтения <see cref="Part"/>
    /// </summary>
    public interface IPartReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="Part"/>
        /// </summary>
        Task<IReadOnlyCollection<Part>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Part"/> по идентификатору
        /// </summary>
        Task<Part?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить список <see cref="Part"> по идентификаторам
        /// </summary>
        Task<Dictionary<Guid, Part>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellation);

        /// <summary>
        /// Проверить есть ли <see cref="Part"/> в коллеции
        /// </summary>
        Task<bool> IsNotNullAsync(Guid id, CancellationToken cancellationToken);
    }
}
