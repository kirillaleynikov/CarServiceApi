using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Services.Contracts.ModelsRequest
{
    public class ServiceRequestModel
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
