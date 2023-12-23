using CarService.Services.Contracts.Models;

namespace CarService.Services.Contracts.Interface
{
    public interface IPartService
    {
        /// <summary>
        /// Получить список всех <see cref="PartModel"/>
        /// </summary>
        Task<IEnumerable<PartModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="PartModel"/> по идентификатору
        /// </summary>
        Task<PartModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<PartModel> AddAsync(string name, DateTime dateOfBirth, string phoneNumber, CancellationToken cancellationToken);

        Task<PartModel> EditAsync(PartModel source, CancellationToken cancellationToken);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
