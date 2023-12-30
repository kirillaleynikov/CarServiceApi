using CarService.API.Models.CreateRequest;

namespace CarService.API.Models.Request
{
    public class RepairRequest : CreateRepairRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
