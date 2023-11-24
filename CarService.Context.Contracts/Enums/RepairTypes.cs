using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Context.Contracts.Enums
{
    public enum RepairTypes
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
