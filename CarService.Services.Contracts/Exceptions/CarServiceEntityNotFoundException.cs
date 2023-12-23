namespace CarService.Services.Contracts.Exceptions
{
    /// <summary>
    /// Запрашиваемая сущность не найдена
    /// </summary>
    public class CarServiceEntityNotFoundException<TEntity> : CarServiceNotFoundException
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="CarServiceEntityNotFoundException{TEntity}"/>
        /// </summary>
        public CarServiceEntityNotFoundException(Guid id)
            : base($"Сущность {typeof(TEntity)} c id = {id} не найдена.")
        {
        }
    }
}
