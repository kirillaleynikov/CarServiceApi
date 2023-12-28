using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CarService.Api.Attribute;
using CarService.Api.Infrastructures.Validator;
using CarService.Api.Models;
using CarService.Api.ModelsRequest.Discipline;
using CarService.Services.Contracts.Interface;
using CarService.Services.Contracts.Models;

namespace CarService.Api.Controllers
{
    /// <summary>
    /// CRUD контроллер по работе с Клиентами
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Client")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService clientService;
        //private readonly IApiValidatorService validatorService;
        private readonly IMapper mapper;

        public ClientController(IClientService clientService,
            IMapper mapper
            )
        {
            this.clientService = clientService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ApiOk(typeof(IEnumerable<ClientResponse>))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await clientService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<ClientResponse>>(result));
        }

        [HttpGet("{id:guid}")]
        [ApiOk(typeof(ClientResponse))]
        [ApiNotFound]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await clientService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<ClientResponse>(result));
        }

        /// <summary>
        /// Создаёт новую дисциплину
        /// </summary>
        [HttpPost]
        [ApiOk(typeof(ClientResponse))]
        [ApiConflict]
        public async Task<IActionResult> Create(CreateClientRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var result = await clientService.AddAsync(request.Name, request.Description, cancellationToken);
            return Ok(mapper.Map<ClientResponse>(result));
        }

        /// <summary>
        /// Редактирует имеющуюся дисциплину
        /// </summary>
        [HttpPut]
        [ApiOk(typeof(ClientResponse))]
        [ApiNotFound]
        [ApiConflict]
        public async Task<IActionResult> Edit(ClientRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var model = mapper.Map<ClientModel>(request);
            var result = await clientService.EditAsync(model, cancellationToken);
            return Ok(mapper.Map<ClientResponse>(result));
        }

        /// <summary>
        /// Удаляет имеющуюся дисциплину
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ApiOk(typeof(ClientResponse))]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await clientService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
