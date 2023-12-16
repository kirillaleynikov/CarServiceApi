using CarService.Repositories.Contracts;
using CarService.Services.Contracts;
using CarService.Services.Contracts.Models;

namespace CarService.Services.Implementations
{
    public class RepairService : IRepairService
    {
        private readonly IRepairReadRepository repairReadRepository;

        public RepairService(IRepairReadRepository repairReadRepository)
        {
            this.repairReadRepository = repairReadRepository;
        }

        async Task<IEnumerable<RepairModel>> IRepairService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await repairReadRepository.GetAllAsync(cancellationToken);
            return result.Select(x => new RepairModel
            {
                Service = x.Service,
                PartToChange = x.PartToChange,
                ClientName = x.ClientName,
                MarkCar = x.MarkCar,
                GosNumber = x.GosNumber,
                ClientPhoneNumber = x.ClientPhoneNumber,
                RoomNumber = x.RoomNumber,
                StartRepair = x.StartRepair,
                EndRepair = x.EndRepair,
                RepairType = x.RepairType,
                Price = x.Price,
            });
        }

        async Task<RepairModel?> IRepairService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await repairReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                return null;
            }

            return new RepairModel
            {
                Service = item.Service,
                PartToChange = item.PartToChange,
                ClientName = item.ClientName,
                MarkCar = item.MarkCar,
                GosNumber = item.GosNumber,
                ClientPhoneNumber = item.ClientPhoneNumber,
                RoomNumber = item.RoomNumber,
                StartRepair = item.StartRepair,
                EndRepair = item.EndRepair,
                RepairType = item.RepairType,
                Price = item.Price,
            };
        }
    }
}
