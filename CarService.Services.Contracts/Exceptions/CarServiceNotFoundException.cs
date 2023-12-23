namespace CarService.Services.Contracts.Exceptions
{
    /// <summary>
    /// Запрашиваемый ресурс не найден
    /// </summary>
    public class CarServiceNotFoundException : CarServiceException
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="CarServiceNotFoundException"/> с указанием
        /// сообщения об ошибке
        /// </summary>
        public CarServiceNotFoundException(string message)
            : base(message)
        { }
    }
}
