using CarService.Context.Contracts.Models;

namespace CarService.Repositories.Contracts
{
    /// <summary>
    /// Репозиторий записи <see cref="Room"/>
    /// </summary>
    public interface IRoomWriteRepository : IRepositoryWriter<Room>
    {
    }
}
