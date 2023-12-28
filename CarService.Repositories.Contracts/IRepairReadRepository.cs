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
        Task<IReadOnlyCollection<Repair>> GetAllByDateAsync(DateTimeOffset startDate, DateTimeOffset endDate, CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Repair"/> по идентификатору
        /// </summary>
        Task<Repair?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
