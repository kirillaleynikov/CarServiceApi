using CarService.API.Models.CreateRequest;

namespace CarService.Models.Request
{
    public class PartRequest : CreatePartRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
