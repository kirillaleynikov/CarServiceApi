﻿//using CarService.Common.Entity.InterfaceDB;
//using CarService.Common.Entity.Repositories;
//using CarService.Context.Contracts;
//using CarService.Context.Contracts.Models;
//using CarService.Repositories.Contracts;
//using Microsoft.EntityFrameworkCore;
//using CarService.Repositories.Anchors;

//namespace CarService.Repositories
//{
//    public class RoomReadRepository : IRoomReadRepository, IRepositoryAnchor
//    {
//        private readonly IDbRead reader;

//        public RoomReadRepository(IDbRead reader)
//        {
//            this.reader = reader;
//        }

//        Task<IReadOnlyCollection<Room>> IRoomReadRepository.GetAllAsync(CancellationToken cancellationToken)
//            => reader.Read<Room>()
//                .NotDeletedAt()
//                .OrderBy(x => x.Number)
//                .ToReadOnlyCollectionAsync(cancellationToken);

//        Task<Room?> IRoomReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
//            => reader.Read<Room>()
//            .ById(id)
//            .FirstOrDefaultAsync(cancellationToken);

//        Task<Dictionary<Guid, Room>> IRoomReadRepository.GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellation)
//            => reader.Read<Room>()
//                .NotDeletedAt()
//                .ByIds(ids)
//                .OrderBy(x => x.Number)
//                .ToDictionaryAsync(key => key.Id, cancellation);

//        Task<bool> IRoomReadRepository.IsNotNullAsync(Guid id, CancellationToken cancellationToken)
//            => reader.Read<Room>().AnyAsync(x => x.Id == id && !x.DeletedAt.HasValue, cancellationToken);
//    }
//}