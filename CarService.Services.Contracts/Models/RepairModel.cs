using CarService.Services.Contracts.Models.Enums;

namespace CarService.Services.Contracts.Models
{
    /// <summary>
    /// Ремонт
    /// </summary>
    public class RepairModel
    {
        /// <summary>
        /// Оказанная услуга
        /// </summary>
        public ServiceModel? Service { get; set; }
        /// <summary>
        /// Деталь к замене
        /// </summary>
        public PartModel? PartToChange { get; set; }
        /// <summary>
        /// Имя клиента
        /// </summary>
        public ClientModel? ClientName { get; set; }
        /// <summary>
        /// Марка машины клиента
        /// </summary>
        public string MarkCar { get; set; } = string.Empty;
        /// <summary>
        /// Гос номер машины клиента
        /// </summary>
        public string GosNumber { get; set; } = string.Empty;
        /// <summary>
        /// Номер телефона клиента
        /// </summary>
        public ClientModel? ClientPhoneNumber { get; set; }
        /// <summary>
        /// Номер помещения
        /// </summary>
        public RoomModel? RoomNumber { get; set; }
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
        public RepairTypesModel RepairType { get; set; }
        /// <summary>
        /// Стоимость ремонта
        /// </summary>

        public int Price { get; set; }
    }
}
