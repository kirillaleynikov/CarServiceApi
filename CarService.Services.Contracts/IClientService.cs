﻿using CarService.Services.Contracts.Models;

namespace CarService.Services.Contracts
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
        Task<ClientModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
