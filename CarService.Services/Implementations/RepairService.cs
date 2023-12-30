using AutoMapper;
using CarService.Common.Entity.InterfaceDB;
using CarService.Repositories.Contracts;
using CarService.Services.Anchors;
using CarService.Services.Contracts.Models;
using CarService.Services;
using CarService.Services.Contracts.Interface;
using CarService.Services.Contracts.ModelsRequest;
using CarService.Context.Contracts.Models;
using CarService.Services.Contracts.Exceptions;

namespace CarService.Services.Services
{
    internal class RepairService : IRepairService, IServiceAnhor
    {
        private readonly IRepairWriteRepository repairWriteRepository;
        private readonly IRepairReadRepository repairReadRepository;
        private readonly IEmployeeReadRepository employeeReadRepository;
        private readonly IClientReadRepository clientReadRepository;
        private readonly IPartReadRepository partReadRepository;
        private readonly IServiceReadRepository serviceReadRepository;
        private readonly IRoomReadRepository roomReadRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IServiceValidatorService validatorService;

        public RepairService(IRepairWriteRepository repairWriteRepository, IRepairReadRepository repairReadRepository, IEmployeeReadRepository employeeReadRepository,
            IClientReadRepository clientReadRepository, IPartReadRepository partReadRepository,
           IServiceReadRepository serviceReadRepository, IRoomReadRepository roomReadRepository,
            IMapper mapper, IUnitOfWork unitOfWork, IServiceValidatorService validatorService)
        {
            this.repairWriteRepository = repairWriteRepository;
            this.repairReadRepository = repairReadRepository;
            this.clientReadRepository = clientReadRepository;
            this.employeeReadRepository = employeeReadRepository;
            this.partReadRepository = partReadRepository;
            this.roomReadRepository = roomReadRepository;
            this.serviceReadRepository = serviceReadRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.validatorService = validatorService;
        }

        async Task<RepairModel> IRepairService.AddAsync(RepairRequestModel model, CancellationToken cancellationToken)
        {
            model.Id = Guid.NewGuid();
            await validatorService.ValidateAsync(model, cancellationToken);

            var repair = mapper.Map<Repair>(model);
            repairWriteRepository.Add(repair);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return await GetTicketModelOnMapping(repair, cancellationToken);
        }

        async Task IRepairService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetTicket = await repairReadRepository.GetByIdAsync(id, cancellationToken);

            if (targetTicket == null)
            {
                throw new CarServiceEntityNotFoundException<Repair>(id);
            }

            if (targetTicket.DeletedAt.HasValue)
            {
                throw new CarServiceInvalidOperationException($"Билет с идентификатором {id} уже удален");
            }

            repairWriteRepository.Delete(targetTicket);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

        async Task<RepairModel> IRepairService.EditAsync(RepairRequestModel model, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(model, cancellationToken);

            var repair = await repairReadRepository.GetByIdAsync(model.Id, cancellationToken);

            if (repair == null)
            {
                throw new CarServiceEntityNotFoundException<Repair>(model.Id);
            }

            repair = mapper.Map<Repair>(model);
            repairWriteRepository.Update(repair);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return await GetTicketModelOnMapping(repair, cancellationToken);
        }

        async Task<IEnumerable<RepairModel>> IRepairService.GetAllAsync(CancellationToken cancellationToken)
        {
            var repairs = await repairReadRepository.GetAllAsync(cancellationToken);
            var employees = await employeeReadRepository
                .GetByIdsAsync(repairs.Select(x => x.EmployeeId).Distinct(), cancellationToken);

            var clients = await clientReadRepository
                .GetByIdsAsync(repairs.Select(x => x.ClientId).Distinct(), cancellationToken);

            var parts = await partReadRepository
                .GetByIdsAsync(repairs.Select(x => x.PartId).Distinct(), cancellationToken);

            var rooms = await roomReadRepository
                .GetByIdsAsync(repairs.Select(x => x.RoomId).Distinct(), cancellationToken);

            var services = await serviceReadRepository
                .GetByIdsAsync(repairs.Select(x => x.ServiceId).Distinct(), cancellationToken);


            var result = new List<RepairModel>();

            foreach (var repair in repairs)
            {
                if (!employees.TryGetValue(repair.EmployeeId, out var employee) ||
                !clients.TryGetValue(repair.ClientId, out var client) ||
                !parts.TryGetValue(repair.RepairId, out var part) ||
                !rooms.TryGetValue(repair.RoomId, out var room) ||
                !services.TryGetValue(repair.ServiceId, out var service))
                {
                    continue;
                }
                else
                {
                    var RepairModel = mapper.Map<RepairModel>(repair);

                    RepairModel.EmployeeName = mapper.Map<EmployeeModel>(employee);
                    RepairModel.PartToChange = mapper.Map<PartModel>(part);
                    RepairModel.RoomNumber = mapper.Map<RoomModel>(room);
                    RepairModel.Service = mapper.Map<ServiceModel>(service);
                    RepairModel.ClientName = mapper.Map<ClientModel>(client);

                    result.Add(RepairModel);
                }
            }
            return result;
        }

        async Task<RepairModel?> IRepairService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await repairReadRepository.GetByIdAsync(id, cancellationToken);

            if (item == null)
            {
                throw new CarServiceEntityNotFoundException<Repair>(id);
            }

            return await GetTicketModelOnMapping(item, cancellationToken);
        }

        async private Task<RepairModel> GetTicketModelOnMapping(Repair repair, CancellationToken cancellationToken)
        {
            var RepairModel = mapper.Map<RepairModel>(repair);
            RepairModel.EmployeeName = mapper.Map<EmployeeModel>(await employeeReadRepository.GetByIdAsync(repair.EmployeeId, cancellationToken));
            RepairModel.PartToChange = mapper.Map<PartModel>(await partReadRepository.GetByIdAsync(repair.PartId, cancellationToken));
            RepairModel.RoomNumber = mapper.Map<RoomModel>(await roomReadRepository.GetByIdAsync(repair.RoomId, cancellationToken));
            RepairModel.Service = mapper.Map<ServiceModel>(await serviceReadRepository.GetByIdAsync(repair.ServiceId, cancellationToken));
            RepairModel.ClientName = mapper.Map<ClientModel>(await clientReadRepository.GetByIdAsync(repair.ClientId, cancellationToken));

            return RepairModel;
        }
    }
}
