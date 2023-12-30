using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CarService.Services.Contracts.Interface;
using CarService.Services.Contracts.Models;
using CarService.API.Models.Response;
using CarService.API.Models.Request;
using CarService.API.Models.CreateRequest;
using CarService.API.Exceptions;

namespace CarService.Api.Controllers
{
    /// <summary>
    /// CRUD контроллер по работе с Клиентами
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Service")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService serviceService;
        private readonly IMapper mapper;

        public ServiceController(IServiceService serviceService,
            IMapper mapper
            )
        {
            this.serviceService = serviceService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ServiceResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await serviceService.GetAllAsync(cancellationToken);
            return Ok(result.Select(x => mapper.Map<ServiceResponse>(x)));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ServiceResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionsDetail), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([Required] Guid id, CancellationToken cancellationToken)
        {
            var item = await serviceService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<ServiceResponse>(item));
        }

        /// <summary>
        /// Создаёт новую дисциплину
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ServiceResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiValidationExceptionsDetail), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ApiExceptionsDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add(CreateServiceRequest model, CancellationToken cancellationToken)
        {
            var serviceModel = mapper.Map<ServiceModel>(model);
            var result = await serviceService.AddAsync(serviceModel, cancellationToken);
            return Ok(mapper.Map<ServiceResponse>(result));
        }

        /// <summary>
        /// Редактирует имеющуюся дисциплину
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(ServiceResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionsDetail), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiValidationExceptionsDetail), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ApiExceptionsDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Edit(ServiceRequest request, CancellationToken cancellationToken)
        {
            var model = mapper.Map<ServiceModel>(request);
            var result = await serviceService.EditAsync(model, cancellationToken);
            return Ok(mapper.Map<ServiceResponse>(result));
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
            await serviceService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
