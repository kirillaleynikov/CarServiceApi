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
        Task<List<Client>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Repair"/> по идентификатору
        /// </summary>
        Task<Client?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
