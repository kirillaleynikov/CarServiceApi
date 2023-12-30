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
    [ApiExplorerSettings(GroupName = "Room")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService roomService;
        private readonly IMapper mapper;

        public RoomController(IRoomService roomService,
            IMapper mapper
            )
        {
            this.roomService = roomService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RoomResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await roomService.GetAllAsync(cancellationToken);
            return Ok(result.Select(x => mapper.Map<RoomResponse>(x)));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(RoomResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionsDetail), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([Required] Guid id, CancellationToken cancellationToken)
        {
            var item = await roomService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<RoomResponse>(item));
        }

        /// <summary>
        /// Создаёт новую дисциплину
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(RoomResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiValidationExceptionsDetail), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ApiExceptionsDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add(CreatePartRequest model, CancellationToken cancellationToken)
        {
            var roomModel = mapper.Map<RoomModel>(model);
            var result = await roomService.AddAsync(roomModel, cancellationToken);
            return Ok(mapper.Map<RoomResponse>(result));
        }

        /// <summary>
        /// Редактирует имеющуюся дисциплину
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(RoomResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExceptionsDetail), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiValidationExceptionsDetail), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ApiExceptionsDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Edit(RoomRequest request, CancellationToken cancellationToken)
        {
            var model = mapper.Map<RoomModel>(request);
            var result = await roomService.EditAsync(model, cancellationToken);
            return Ok(mapper.Map<RoomResponse>(result));
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
            await roomService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
