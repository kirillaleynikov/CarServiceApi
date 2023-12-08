using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService.Api.Models;
using CarService.Api.Models.Enums;
using CarService.Context.Contracts.Enums;

namespace CarService.Api.Models
{
    /// <summary>
    /// Ремонт
    /// </summary>
    public class RoomResponse
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
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Статус помещения
        /// </summary>
        /// <inheritdoc cref="RoomTypes"/>
        public RoomTypes RoomType { get; set; }
    }
}
