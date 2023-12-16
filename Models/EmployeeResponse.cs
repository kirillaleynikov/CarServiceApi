using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService.Api.Models;
using CarService.Api.Models.Enums;

namespace CarService.Api.Models
{
    /// <summary>
    /// Ремонт
    /// </summary>
    public class EmployeeResponse
    {
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
    }
}
