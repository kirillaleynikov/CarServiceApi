namespace CarService.API.Models.Response
{
    /// <summary>
    /// Ремонт
    /// </summary>
    public class ServiceResponse
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
    }
}
