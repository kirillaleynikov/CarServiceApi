using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService.Context.Contracts.Enums;

namespace CarService.Context.Contracts.Models
{
    /// <summary>
    /// Ремонт
    /// </summary>
    public class Repair : BaseAuditEntity
    {
        /// <summary>
        /// Оказанная услуга
        /// </summary>
        public Guid ServiceId { get; set; }
        public Service Service { get; set; }
        /// <summary>
        /// Деталь к замене
        /// </summary>
        public Guid PartId { get; set; }
        public Part PartToChange { get; set; }
        /// <summary>
        /// Имя клиента
        /// </summary>
        public Guid ClientId { get; set; }
        public Client ClientName { get; set; }
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
        public Room RoomNumber { get; set; }
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
        public Guid RepairId { get; set; }
        public RepairTypes RepairType { get; set; }
        /// <summary>
        /// Стоимость ремонта
        /// </summary>
        public int Price { get; set; }
    }
}
