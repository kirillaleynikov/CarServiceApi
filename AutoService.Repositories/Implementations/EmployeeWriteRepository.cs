using CarService.Common.Entity.InterfaceDB;
using CarService.Context.Contracts.Models;
using CarService.Repositories.Contracts;

namespace CarService.Repositories.Implementations
{
    /// <inheritdoc cref="IEmployeeWriteRepository"/>
    public class EmployeeWriteRepository : BaseWriteRepository<Employee>,
        IEmployeeWriteRepository,
        IRepositoryAnchor
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="EmployeeWriteRepository"/>
        /// </summary>
        public EmployeeWriteRepository(IDbWriterContext writerContext)
            : base(writerContext)
        {
        }
    }
}
