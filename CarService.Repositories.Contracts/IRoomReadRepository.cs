using CarService.Context.Contracts.Models;

namespace CarService.Repositories.Contracts
{
    /// <summary>
    /// Репозиторий чтения <see cref="Room"/>
    /// </summary>
    public interface IRoomReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="Room"/>
        /// </summary>
        Task<List<Room>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Room"/> по идентификатору
        /// </summary>
        Task<Room?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
