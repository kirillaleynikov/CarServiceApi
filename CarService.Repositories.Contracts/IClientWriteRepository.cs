using CarService.Context.Contracts.Models;

namespace CarService.Repositories.Contracts
{
    /// <summary>
    /// Репозиторий записи <see cref="ClientRequestValidator"/>
    /// </summary>
    public interface IClientWriteRepository : IRepositoryWriter<Client>
    {
    }
}
