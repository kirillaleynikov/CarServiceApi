using CarService.General;

namespace CarService.API.Exceptions
{
    /// <summary>
    /// Информация об ошибках валидации работы АПИ
    /// </summary>
    public class ApiValidationExceptionsDetail
    {
        /// <summary>
        /// Ошибки валидации
        /// </summary>
        public IEnumerable<InvalidateItemModel> Errors { get; set; } = Array.Empty<InvalidateItemModel>();
    }
}
