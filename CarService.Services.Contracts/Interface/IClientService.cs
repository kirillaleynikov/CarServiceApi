using CarService.Services.Contracts.Models;

namespace CarService.Services.Contracts.Interface
{
    public interface IClientService
    {
        /// <summary>
        /// Получить список всех <see cref="ClientModel"/>
        /// </summary>
        Task<IEnumerable<ClientModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="ClientModel"/> по идентификатору
        /// </summary>
        Task<ClientModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<ClientModel> AddAsync(string name, DateTime dateOfBirth, string phoneNumber, string email, CancellationToken cancellationToken);

        Task<ClientModel> EditAsync(ClientModel source, CancellationToken cancellationToken);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
