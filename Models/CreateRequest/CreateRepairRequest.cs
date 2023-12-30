using CarService.API.Enums;


namespace CarService.API.Models.CreateRequest
{
    public class CreateRepairRequest
    {
        /// <summary>
        /// Оказанная услуга
        /// </summary>
        public Guid ServiceId { get; set; }
        /// <summary>
        /// Деталь к замене
        /// </summary>
        public Guid PartId { get; set; }
        /// <summary>
        /// Имя клиента
        /// </summary>
        public Guid ClientId { get; set; }
        /// <summary>
        /// Марка машины клиента
        /// </summary>
        public string MarkCar { get; set; } = string.Empty;
        /// <summary>
        /// Гос номер машины клиента
        /// </summary>
        public string GosNumber { get; set; } = string.Empty;
        /// <summary>
        /// Номер помещения
        /// </summary>
        public Guid RoomId { get; set; }
        /// <summary>
        /// Дата начала ремонта
        /// </summary>
        public DateTimeOffset? StartRepair { get; set; }
        /// <summary>
        /// Дата окончания ремонта
        /// </summary>
        public DateTimeOffset? EndRepair { get; set; }
        /// <summary>
        /// Статус ремонта
        /// </summary>

        /// <inheritdoc cref="RepairTypes"/>
        public RepairTypesResponse RepairType { get; set; }
        /// <summary>
        /// Стоимость ремонта
        /// </summary>
    }
}
