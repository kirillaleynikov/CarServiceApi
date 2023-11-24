using CarService.Context.Contracts.Models;

namespace CarService.Repositories.Contracts
{
    /// <summary>
    /// Репозиторий чтения <see cref="Discipline"/>
    /// </summary>
    public interface IRepairReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="Discipline"/>
        /// </summary>
        Task<List<Repair>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Discipline"/> по идентификатору
        /// </summary>
        Task<Repair?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
