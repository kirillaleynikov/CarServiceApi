using CarService.Shared;

namespace CarService.Services.Contracts.Exceptions
{
    /// <summary>
    /// Ошибки валидации
    /// </summary>
    public class CarServiceValidationException : CarServiceException
    {
        /// <summary>
        /// Ошибки
        /// </summary>
        public IEnumerable<InvalidateItemModel> Errors { get; }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="AdministrationValidationException"/>
        /// </summary>
        public CarServiceValidationException(IEnumerable<InvalidateItemModel> errors)
        {
            Errors = errors;
        }
    }
}
