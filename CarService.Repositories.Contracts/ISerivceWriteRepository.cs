using CarService.Context.Contracts.Models;

namespace CarService.Repositories.Contracts
{
    /// <summary>
    /// Репозиторий записи <see cref="Service"/>
    /// </summary>
    public interface IServiceWriteRepository : IRepositoryWriter<Service>
    {
    }
}
