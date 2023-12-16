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
