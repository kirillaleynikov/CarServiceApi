using CarService.Context.Contracts.Models;

namespace CarService.Repositories.Contracts
{
    /// <summary>
    /// Репозиторий записи <see cref="Repair"/>
    /// </summary>
    public interface IRepairWriteRepository : IRepositoryWriter<Repair>
    {
    }
}
