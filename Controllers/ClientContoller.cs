using Microsoft.AspNetCore.Mvc;
using CarService.Api.Models;
using CarService.Services.Contracts;

namespace CarService.Api.Controllers
{
    /// <summary>
    /// CRUD контроллер по работу с Дисциплинами
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DisciplineController : ControllerBase
    {
        private readonly IDisciplineService disciplineService;

        public DisciplineController(IDisciplineService disciplineService)
        {
            this.disciplineService = disciplineService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await disciplineService.GetAllAsync(cancellationToken);
            return Ok(result.Select(x => new DisciplineResponse
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await disciplineService.GetByIdAsync(id, cancellationToken);
            if (result == null)
            {
                return NotFound($"Не удалось найти дисциплину с идентификатором {id}");
            }

            return Ok(new DisciplineResponse
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description,
            });
        }
    }
}
