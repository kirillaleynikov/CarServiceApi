using CarService.Context.Contracts.Models;

namespace CarService.Repositories.Contracts
{
    /// <summary>
    /// Репозиторий записи <see cref="Part"/>
    /// </summary>
    public interface IPartWriteRepository : IRepositoryWriter<Part>
    {
    }
}
