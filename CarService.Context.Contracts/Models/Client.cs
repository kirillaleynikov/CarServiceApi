﻿using CarService.Context.Contracts.Models;
using System;

namespace AutoService.Context.Contracts.Models
{
    /// <summary>
    /// Клиент
    /// </summary>
    public class Client : BaseAuditEntity
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
