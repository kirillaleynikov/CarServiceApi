namespace CarService.API.Models.CreateRequest
{
    /// <summary>
    /// Модель запроса создания дисциплины
    /// </summary>
    public class CreateEmployeeRequest
    {
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
