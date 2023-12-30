using CarService.API.Models.CreateRequest;

namespace CarService.API.Models.Request
{
    public class RoomRequest : CreateRoomRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
