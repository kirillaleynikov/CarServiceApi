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
        Task<List<Part>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Part"/> по идентификатору
        /// </summary>
        Task<Part?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
