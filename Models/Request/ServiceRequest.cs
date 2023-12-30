using CarService.API.Models.CreateRequest;

namespace CarService.API.Models.Request
{
    public class ServiceRequest : CreateServiceRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
