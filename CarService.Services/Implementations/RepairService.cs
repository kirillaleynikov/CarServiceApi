//using AutoMapper;
//using CarService.Common.Entity.InterfaceDB;
//using CarService.Repositories.Contracts;
//using CarService.Services.Contracts;
//using CarService.Services.Contracts.Interface;
//using CarService.Services.Contracts.Models;
//using Serilog;
//using System.Security.AccessControl;

//namespace CarService.Services.Implementations
//{
//    public class RepairService : IRepairService, IServiceAnchor
//    {
//        private readonly IRepairReadRepository repairReadRepository;
//        private readonly IRepairWriteRepository repairWriteRepository;
//        private readonly IClientReadRepository clientReadRepository;
//        private readonly IEmployeeReadRepository employeeReadRepository;
//        private readonly IPartReadRepository partReadRepository;
//        private readonly IRoomReadRepository roomReadRepository;
//        private readonly IServiceReadRepository serviceReadRepository;

//        public RepairService(IRepairReadRepository repairReadRepository,
//            IRepairWriteRepository repairWriteRepository,
//            IClientReadRepository clientReadRepository,
//            IEmployeeReadRepository employeeReadRepository,
//            IPartReadRepository partReadRepository,
//            IRoomReadRepository roomReadRepository,
//            IServiceReadRepository serviceReadRepository,
//            IUnitOfWork unitOfWork,
//            IMapper mapper)
//        {
//            this.repairReadRepository = repairReadRepository;
//            this.repairWriteRepository = repairWriteRepository;
//            this.clientReadRepository = clientReadRepository;
//            this.employeeReadRepository = employeeReadRepository;
//            this.partReadRepository = partReadRepository;
//            this.roomReadRepository = roomReadRepository;
//            this.serviceReadRepository = serviceReadRepository;
//        }

//        async Task<IEnumerable<RepairModel>> IRepairService.GetAllAsync(DateTimeOffset targetDate, CancellationToken cancellationToken)
//        {
//            var repair = await repairReadRepository.GetAllByDateAsync(targetDate.Date, targetDate.Date.AddDays(1).AddMilliseconds(-1), cancellationToken);

//            var clientIds = repair.Select(x => x.ClientId).Distinct();
//            var employeeIds = repair.Select(x => x.EmployeeId).Distinct();
//            var partIds = repair.Select(x => x.PartId).Distinct();
//            var roomIds = repair.Select(x => x.RoomId).Distinct();
//            var serviceIds = repair.Select(x => x.ServiceId).Distinct();

//            var clientDictionary = await clientReadRepository.GetByIdsAsync(clientIds, cancellationToken);
//            var employeeDictionary = await employeeReadRepository.GetByIdsAsync(employeeIds, cancellationToken);
//            var partDictionary = await partReadRepository.GetByIdsAsync(partIds, cancellationToken);

//            var listRepairModel = new List<RepairModel>();
//            foreach (var repair in repairs)
//            {
//                cancellationToken.ThrowIfCancellationRequested();
//                if (!clientDictionary.TryGetValue(repair.ClientId, out var client))
//                {
//                    Log.Warning("Запрос вернул null(Client) IClientService.GetAllAsync");
//                    continue;
//                }
//                if (!groupDictionary.TryGetValue(timeTableItem.GroupId, out var group))
//                {
//                    Log.Warning("Запрос вернул null(Discipline) ITimeTableItemService.GetAllAsync");
//                    continue;
//                }
//                if (timeTableItem.TeacherId == null ||
//                    !teacherDictionary.TryGetValue(timeTableItem.TeacherId.Value, out var teacher))
//                {
//                    Log.Warning("Запрос вернул null(TeacherId) ITimeTableItemService.GetAllAsync");
//                    continue;
//                }
//                var repair = mapper.Map<RepairModel>(repair);
//                repair.Discipline = mapper.Map<ClientModel>(client);
//                repair.Group = mapper.Map<GroupModel>(group);
//                timeTable.Teacher = mapper.Map<PersonModel>(teacher);

//                listTimeTableItemModel.Add(timeTable);
//            }

//            return listTimeTableItemModel;
//        }

//        async Task<RepairModel?> IRepairService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
//        {
//            var item = await repairReadRepository.GetByIdAsync(id, cancellationToken);
//            if (item == null)
//            {
//                return null;
//            }
//            var discipline = await disciplineReadRepository.GetByIdAsync(item.DisciplineId, cancellationToken);
//            var group = await groupReadRepository.GetByIdAsync(item.GroupId, cancellationToken);
//            var timeTable = mapper.Map<TimeTableItemModel>(item);
//            timeTable.Discipline = discipline != null
//                ? mapper.Map<DisciplineModel>(discipline)
//                : null;
//            timeTable.Group = group != null
//               ? mapper.Map<GroupModel>(group)
//               : null;
//            if (item.TeacherId != null)
//            {
//                var personDictionary = await employeeReadRepository.GetPersonByEmployeeIdsAsync(new[] { item.TeacherId.Value }, cancellationToken);
//                timeTable.Teacher = personDictionary.TryGetValue(item.TeacherId.Value, out var teacher)
//                  ? mapper.Map<PersonModel>(teacher)
//                  : null;
//            }
//            return timeTable;
//        }

//        async Task<TimeTableItemModel> ITimeTableItemService.AddAsync(TimeTableItemRequestModel timeTable, CancellationToken cancellationToken)
//        {
//            var item = new TimeTableItem
//            {
//                Id = Guid.NewGuid(),
//                StartDate = timeTable.StartDate,
//                EndDate = timeTable.EndDate,
//                RoomNumber = timeTable.RoomNumber,
//                TeacherId = timeTable.Teacher,
//                DisciplineId = timeTable.Discipline,
//                GroupId = timeTable.Group,
//            };

//            timeTableItemWriteRepository.Add(item);
//            await unitOfWork.SaveChangesAsync(cancellationToken);
//            return mapper.Map<TimeTableItemModel>(item);
//        }

//        async Task<TimeTableItemModel> ITimeTableItemService.EditAsync(TimeTableItemRequestModel source, CancellationToken cancellationToken)
//        {
//            var targetTimeTableItem = await timeTableItemReadRepository.GetByIdAsync(source.Id, cancellationToken);

//            if (targetTimeTableItem == null)
//            {
//                throw new TimeTableEntityNotFoundException<TimeTableItem>(source.Id);
//            }

//            targetTimeTableItem.StartDate = source.StartDate;
//            targetTimeTableItem.EndDate = source.EndDate;
//            targetTimeTableItem.RoomNumber = source.RoomNumber;

//            var employee = await employeeReadRepository.GetByIdAsync(source.Teacher, cancellationToken);
//            targetTimeTableItem.TeacherId = employee!.Id;
//            targetTimeTableItem.Teacher = employee;

//            var group = await groupReadRepository.GetByIdAsync(source.Group, cancellationToken);
//            targetTimeTableItem.GroupId = group!.Id;
//            targetTimeTableItem.Group = group;

//            var discipline = await disciplineReadRepository.GetByIdAsync(source.Discipline, cancellationToken);
//            targetTimeTableItem.DisciplineId = discipline!.Id;
//            targetTimeTableItem.Discipline = discipline;

//            timeTableItemWriteRepository.Update(targetTimeTableItem);
//            await unitOfWork.SaveChangesAsync(cancellationToken);
//            return mapper.Map<TimeTableItemModel>(targetTimeTableItem);
//        }

//        async Task ITimeTableItemService.DeleteAsync(Guid id, CancellationToken cancellationToken)
//        {
//            var targetTimeTableItem = await timeTableItemReadRepository.GetByIdAsync(id, cancellationToken);
//            if (targetTimeTableItem == null)
//            {
//                throw new TimeTableEntityNotFoundException<TimeTableItem>(id);
//            }
//            if (targetTimeTableItem.DeletedAt.HasValue)
//            {
//                throw new TimeTableInvalidOperationException($"Расписание с идентификатором {id} уже удален");
//            }

//            timeTableItemWriteRepository.Delete(targetTimeTableItem);
//            await unitOfWork.SaveChangesAsync(cancellationToken);
//        }
//    }
//}
