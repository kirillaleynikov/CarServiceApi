using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CarService.Api.Attribute;
using CarService.Api.Infrastructures.Validator;
using CarService.Api.Models;
using CarService.Api.ModelsRequest.Client;
using CarService.Services.Contracts.Interface;
using CarService.Services.Contracts.Models;
using CarService.Api.ModelsRequest.Employee;
using CarService.Services.Implementations;

namespace CarService.Api.Controllers
{
    /// <summary>
    /// CRUD контроллер по работе с Клиентами
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        private readonly IApiValidatorService validatorService;
        private readonly IMapper mapper;

        public EmployeeController(IEmployeeService employeeService,
            IMapper mapper
            )
        {
            this.employeeService = employeeService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ApiOk(typeof(IEnumerable<EmployeeResponse>))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await employeeService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<EmployeeResponse>>(result));
        }

        [HttpGet("{id:guid}")]
        [ApiOk(typeof(EmployeeResponse))]
        [ApiNotFound]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await employeeService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<EmployeeResponse>(result));
        }

        /// <summary>
        /// Создаёт новую дисциплину
        /// </summary>
        [HttpPost]
        [ApiOk(typeof(EmployeeResponse))]
        [ApiConflict]
        public async Task<IActionResult> Create(CreateEmployeeRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var result = await requestService.AddAsync(request.Name, request.DateOfBirth, request.PhoneNumber, cancellationToken);
            return Ok(mapper.Map<EmployeeResponse>(result));
        }

        /// <summary>
        /// Редактирует имеющуюся дисциплину
        /// </summary>
        [HttpPut]
        [ApiOk(typeof(EmployeeResponse))]
        [ApiNotFound]
        [ApiConflict]
        public async Task<IActionResult> Edit(ClientRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var model = mapper.Map<EmployeeModel>(request);
            var result = await employeeService.EditAsync(model, cancellationToken);
            return Ok(mapper.Map<EmployeeResponse>(result));
        }

        /// <summary>
        /// Удаляет имеющуюся дисциплину
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ApiOk(typeof(EmployeeResponse))]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await employeeService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
