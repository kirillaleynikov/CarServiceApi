using CarService.Context.Contracts.Models;

namespace CarService.Repositories.Contracts
{
    /// <summary>
    /// Репозиторий записи <see cref="Client"/>
    /// </summary>
    public interface IClientWriteRepository : IRepositoryWriter<Client>
    {
    }
}
