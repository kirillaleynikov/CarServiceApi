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
        Task<List<Service>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Service"/> по идентификатору
        /// </summary>
        Task<Service?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
