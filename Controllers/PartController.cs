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
    public class PartController : ControllerBase
    {
        private readonly IPartService partService;

        public PartController(IPartService partService)
        {
            this.partService = partService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await partService.GetAllAsync(cancellationToken);
            return Ok(result.Select(x => new PartResponse
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Auto = x.Auto,
                Country = x.Country,
            }));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await partService.GetByIdAsync(id, cancellationToken);
            if (result == null)
            {
                return NotFound($"Не удалось найти ремонт с идентификатором {id}");
            }

            return Ok(new PartResponse
            {
                Id = result.Id,
                Name = result.Name,
                Price = result.Price,
                Auto = result.Auto,
                Country = result.Country,
            });
        }
    }
}
