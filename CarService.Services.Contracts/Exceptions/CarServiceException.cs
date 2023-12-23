namespace CarService.Services.Contracts.Exceptions
{
    /// <summary>
    /// Базовый класс исключений
    /// </summary>
    public abstract class CarServiceException : Exception
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="CarServiceException"/> без параметров
        /// </summary>
        protected CarServiceException() { }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="CarServiceException"/> с указанием
        /// сообщения об ошибке
        /// </summary>
        protected CarServiceException(string message)
            : base(message) { }
    }
}
