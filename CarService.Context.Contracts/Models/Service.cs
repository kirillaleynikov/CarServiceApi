using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Context.Contracts.Models
{
    /// <summary>
    /// Услуга
    /// </summary>
    public class Service : BaseAuditEntity
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
