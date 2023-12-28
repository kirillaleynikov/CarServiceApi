using CarService.Services.Contracts.Models.Enums;
using CarService.Services.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Services.Contracts.ModelsRequest
{
    public class RepairRequestModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Оказанная услуга
        /// </summary>
        public Guid Service { get; set; }
        /// <summary>
        /// Деталь к замене
        /// </summary>
        public Guid PartToChange { get; set; }
        /// <summary>
        /// Имя клиента
        /// </summary>
        public Guid ClientName { get; set; }
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
        public Guid ClientPhoneNumber { get; set; }
        /// <summary>
        /// Номер помещения
        /// </summary>
        public Guid RoomNumber { get; set; }
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
