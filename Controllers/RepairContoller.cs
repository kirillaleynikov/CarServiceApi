using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CarService.Services.Contracts.Interface;
using CarService.Services.Contracts.Models;
using CarService.API.Models.Response;
using CarService.API.Models.Request;
using CarService.API.Exceptions;
using CarService.API.Models.CreateRequest;
using CarService.Models.Request;
using CarService.Services.Contracts.ModelsRequest;

namespace CarService.Api.Controllers
{
    /// <summary>
    /// CRUD контроллер по работе с Клиентами
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Repair")]
    public class RepairController : ControllerBase
    {
        private readonly IRepairService repairService;
        private readonly IMapper mapper;

        public RepairController(IRepairService repairService,
            IMapper mapper
            )
        {
            this.repairService = repairService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<RepairResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await repairService.GetAllAsync(cancellationToken);
            var result2 = result.Select(x => mapper.Map<RepairResponse>(x));
            return Ok(result2);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(RepairResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionsDetail), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([Required] Guid id, CancellationToken cancellationToken)
        {
            var item = await repairService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<RepairResponse>(item));
        }

        /// <summary>
        /// Создаёт новую дисциплину
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(RepairResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiValidationExceptionsDetail), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ApiExceptionsDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add(CreateRepairRequest request, CancellationToken cancellationToken)
        {
            var model = mapper.Map<RepairRequestModel>(request);
            var result = await repairService.AddAsync(model, cancellationToken);
            return Ok(mapper.Map<RepairResponse>(result));
        }

        /// <summary>
        /// Редактирует имеющуюся дисциплину
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(RepairResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionsDetail), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiValidationExceptionsDetail), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ApiExceptionsDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Edit(RepairRequest request, CancellationToken cancellationToken)
        {
            var model = mapper.Map<RepairRequestModel>(request);
            var result = await repairService.EditAsync(model, cancellationToken);
            return Ok(mapper.Map<RepairResponse>(result));
        }

        /// <summary>
        /// Удаляет имеющуюся дисциплину
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionsDetail), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiExceptionsDetail), StatusCodes.Status417ExpectationFailed)]
        public async Task<IActionResult> Delete([Required] Guid id, CancellationToken cancellationToken)
        {
            await repairService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
