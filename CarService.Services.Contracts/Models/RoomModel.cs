using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService.Services.Contracts.Models.Enums;

namespace CarService.Services.Contracts.Models
{
    /// <summary>
    /// Помещение для ремонта
    /// </summary>
    public class RoomModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Номер помещения
        /// </summary>
        public string Number { get; set; } = string.Empty;
        /// <summary>
        /// Площадь помещения
        /// </summary>
        public string Square { get; set; } = string.Empty;
        /// <summary>
        /// Ответственный за помещение
        /// </summary>
        public EmployeeModel? EmployeeId { get; set; }
        /// <summary>
        /// Статус помещения
        /// </summary>
        /// <inheritdoc cref="RoomTypes"/>
        public RoomTypesModel RoomType { get; set; }
    }
}
