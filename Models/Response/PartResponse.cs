namespace CarService.API.Models.Response
{
    /// <summary>
    /// Ремонт
    /// </summary>
    public class PartResponse
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Стоимость
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// Автомобиль
        /// </summary>
        public string Auto { get; set; } = string.Empty;
        /// <summary>
        /// Страна производства
        /// </summary>
        public string Country { get; set; } = string.Empty;
    }
}
