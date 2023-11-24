using Microsoft.AspNetCore.Mvc;
using CarService.Services.Contracts;
using CarService.Api.Models;
using CarService.Api.Models.Enums;

namespace CarService.Api.Controllers
{
    /// <summary>
    /// CRUD контроллер по работе с Ремонтами
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class RepairController : ControllerBase
    {
        private readonly IRepairService repairService;

        public RepairController(IRepairService repairService)
        {
            this.repairService = repairService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await repairService.GetAllAsync(cancellationToken);
            return Ok(result.Select(x => new RepairResponse
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
            }));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await repairService.GetByIdAsync(id, cancellationToken);
            if (result == null)
            {
                return NotFound($"Не удалось найти ремонт с идентификатором {id}");
            }

            return Ok(new RepairResponse
            {
                Service = result.Service,
                PartToChange = result.PartToChange,
                ClientName = result.ClientName,
                MarkCar = result.MarkCar,
                GosNumber = result.GosNumber,
                ClientPhoneNumber = result.ClientPhoneNumber,
                RoomNumber = result.RoomNumber,
                StartRepair = result.StartRepair,
                EndRepair = result.EndRepair,
                RepairType = result.RepairType,
                Price = result.Price,
            });
        }
    }
}
