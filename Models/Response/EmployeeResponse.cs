namespace CarService.API.Models.Response
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
