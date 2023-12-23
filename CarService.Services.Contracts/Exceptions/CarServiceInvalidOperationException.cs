namespace CarService.Services.Contracts.Exceptions
{
    /// <summary>
    /// Ошибка выполнения операции
    /// </summary>
    public class CarServiceInvalidOperationException : CarServiceException
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="CarServiceInvalidOperationException"/>
        /// с указанием сообщения об ошибке
        /// </summary>
        public CarServiceInvalidOperationException(string message)
            : base(message)
        {

        }
    }
}
