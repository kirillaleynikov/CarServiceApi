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

namespace CarService.Api.Controllers
{
    /// <summary>
    /// CRUD контроллер по работе с Клиентами
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Part")]
    public class PartController : ControllerBase
    {
        private readonly IPartService partService;
        private readonly IMapper mapper;

        public PartController(IPartService partService,
            IMapper mapper
            )
        {
            this.partService = partService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PartResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await partService.GetAllAsync(cancellationToken);
            return Ok(result.Select(x => mapper.Map<PartResponse>(x)));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(PartResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionsDetail), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([Required] Guid id, CancellationToken cancellationToken)
        {
            var item = await partService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<PartResponse>(item));
        }

        /// <summary>
        /// Создаёт новую дисциплину
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(PartResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiValidationExceptionsDetail), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ApiExceptionsDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add(CreatePartRequest model, CancellationToken cancellationToken)
        {
            var partModel = mapper.Map<PartModel>(model);
            var result = await partService.AddAsync(partModel, cancellationToken);
            return Ok(mapper.Map<EmployeeResponse>(result));
        }

        /// <summary>
        /// Редактирует имеющуюся дисциплину
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(EmployeeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionsDetail), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiValidationExceptionsDetail), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ApiExceptionsDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Edit(PartRequest request, CancellationToken cancellationToken)
        {
            var model = mapper.Map<PartModel>(request);
            var result = await partService.EditAsync(model, cancellationToken);
            return Ok(mapper.Map<PartResponse>(result));
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
            await partService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
