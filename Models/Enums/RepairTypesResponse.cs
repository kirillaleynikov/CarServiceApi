using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Api.Models.Enums
{
    public enum RepairTypesResponse
    {
        /// <summary>
        /// Не определён
        /// </summary>
        None,

        /// <summary>
        /// Не начат
        /// </summary>
        NotStarted,

        /// <summary>
        /// В процессе
        /// </summary>
        InProgress,

        /// <summary>
        /// Закончен
        /// </summary>
        Finished
    }
}
