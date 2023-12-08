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
    public class ClientController : ControllerBase
    {
        private readonly IClientService clientService;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await clientService.GetAllAsync(cancellationToken);
            return Ok(result.Select(x => new ClientResponse
            {
                Id = x.Id,
                Name = x.Name,
                DateOfBirth = x.DateOfBirth,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
            }));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await clientService.GetByIdAsync(id, cancellationToken);
            if (result == null)
            {
                return NotFound($"Не удалось найти ремонт с идентификатором {id}");
            }

            return Ok(new ClientResponse
            {
                Id = result.Id,
                Name = result.Name,
                DateOfBirth = result.DateOfBirth,
                PhoneNumber = result.PhoneNumber,
                Email = result.Email,
            });
        }
    }
}
