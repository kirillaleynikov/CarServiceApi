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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await employeeService.GetAllAsync(cancellationToken);
            return Ok(result.Select(x => new EmployeeResponse
            {
                Id = x.Id,
                Name = x.Name,
                DateOfBirth = x.DateOfBirth,
                PhoneNumber = x.PhoneNumber,
            }));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await employeeService.GetByIdAsync(id, cancellationToken);
            if (result == null)
            {
                return NotFound($"Не удалось найти ремонт с идентификатором {id}");
            }

            return Ok(new EmployeeResponse
            {
                Id = result.Id,
                Name = result.Name,
                DateOfBirth = result.DateOfBirth,
                PhoneNumber = result.PhoneNumber,
            });
        }
    }
}
