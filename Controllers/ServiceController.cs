using Microsoft.AspNetCore.Mvc;
using CarService.Services.Contracts;
using CarService.Api.Models;
using CarService.Api.Models.Enums;
using CarService.Services.Implementations;

namespace CarService.Api.Controllers
{
    /// <summary>
    /// CRUD контроллер по работе с Услугами
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService serviceService;

        public ServiceController(IServiceService serviceService)
        {
            this.serviceService = serviceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await serviceService.GetAllAsync(cancellationToken);
            return Ok(result.Select(x => new ServiceResponse
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
            }));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await serviceService.GetByIdAsync(id, cancellationToken);
            if (result == null)
            {
                return NotFound($"Не удалось найти ремонт с идентификатором {id}");
            }

            return Ok(new ServiceResponse
            {
                Id = result.Id,
                Name = result.Name,
                Price = result.Price,
            });
        }
    }
}
