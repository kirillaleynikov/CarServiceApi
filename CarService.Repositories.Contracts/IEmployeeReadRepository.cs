﻿using CarService.Context.Contracts.Models;

namespace CarService.Repositories.Contracts
{
    /// <summary>
    /// Репозиторий чтения <see cref="Employee"/>
    /// </summary>
    public interface IEmployeeReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="Employee"/>
        /// </summary>
        Task<IReadOnlyCollection<Employee>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Employee"/> по идентификатору
        /// </summary>
        Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Проверка есть ли <see cref="Employee"/> по указанному id
        /// </summary>
        Task<bool> AnyByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить список <see cref="Employee"/> по идентификаторам
        /// </summary>
        Task<Dictionary<Guid, Employee>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellation);
    }
}
