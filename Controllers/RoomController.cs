using Microsoft.AspNetCore.Mvc;
using CarService.Services.Contracts;
using CarService.Api.Models;
using CarService.Api.Models.Enums;
using CarService.Services.Implementations;

namespace CarService.Api.Controllers
{
    /// <summary>
    /// CRUD контроллер по работе с Клиентами
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService roomService;

        public RoomController(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await roomService.GetAllAsync(cancellationToken);
            return Ok(result.Select(x => new RoomResponse
            {
                Id = x.Id,
                Number = x.Number,
                Square = x.Square,
                EmployeeId = x.EmployeeId,
                RoomType = x.RoomType,
            }));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await roomService.GetByIdAsync(id, cancellationToken);
            if (result == null)
            {
                return NotFound($"Не удалось найти ремонт с идентификатором {id}");
            }

            return Ok(new RoomResponse
            {
                Id = result.Id,
                Number = result.Number,
                Square = result.Square,
                EmployeeId = result.EmployeeId,
                RoomType = result.RoomType,
            });
        }
    }
}
