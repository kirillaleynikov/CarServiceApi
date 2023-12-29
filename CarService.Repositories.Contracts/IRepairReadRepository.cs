using CarService.Context.Contracts.Models;

namespace CarService.Repositories.Contracts
{
    /// <summary>
    /// Репозиторий чтения <see cref="Repair"/>
    /// </summary>
    public interface IRepairReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="Repair"/>
        /// </summary>
        Task<IReadOnlyCollection<Repair>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Repair"/> по идентификатору
        /// </summary>
        Task<Repair?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Проверить есть ли <see cref="Repair"/> в коллеции
        /// </summary>
        Task<bool> IsNotNullAsync(Guid id, CancellationToken cancellationToken);
    }
}
