using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Services.Contracts.ModelsRequest
{
    public class ClientRequestModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// ФИО
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;
        /// <summary>
        /// E-mail
        /// </summary>
        public string Email { get; set; } = string.Empty;
    }
}
