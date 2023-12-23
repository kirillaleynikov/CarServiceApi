using CarService.Context.Contracts.Models;

namespace CarService.Repositories.Contracts
{
    /// <summary>
    /// Репозиторий чтения <see cref="Client"/>
    /// </summary>
    public interface IClientReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="Client"/>
        /// </summary>
        Task<IReadOnlyCollection<Client>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Client"/> по идентификатору
        /// </summary>
        Task<Client?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Проверка есть ли <see cref="Client"/> по указанному id
        /// </summary>
        Task<bool> AnyByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить список <see cref="Client"/> по идентификаторам
        /// </summary>
        Task<Dictionary<Guid, Client>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellation);
    }
}
