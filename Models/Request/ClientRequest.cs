using CarService.API.Models.CreateRequest;

namespace CarService.API.Models.Request
{
    public class ClientRequest : CreatePartRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
