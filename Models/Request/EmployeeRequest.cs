using CarService.API.Models.CreateRequest;

namespace CarService.API.Models.Request
{
    public class EmployeeRequest : CreateEmployeeRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
