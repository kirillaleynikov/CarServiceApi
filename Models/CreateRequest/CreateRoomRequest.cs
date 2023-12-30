using CarService.Context.Contracts.Models;
using CarService.API.Enums;

namespace CarService.API.Models.CreateRequest
{
    public class CreateRoomRequest
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Номер помещения
        /// </summary>
        public string Number { get; set; } = string.Empty;
        /// <summary>
        /// Площадь помещения
        /// </summary>
        public string Square { get; set; } = string.Empty;

        /// <summary>
        /// Ответственный за помещение
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Ответственный за помещение
        /// </summary>
        public Employee? Employee { get; set; }
        /// <summary>
        /// Статус помещения
        /// </summary>
        /// <inheritdoc cref="RoomTypes"/>
        public RoomTypesResponse RoomType { get; set; }
    }
}
