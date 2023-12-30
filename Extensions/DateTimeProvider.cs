using CarService.Common.Entity;

namespace CarService.API.Extensions
{
    /// <summary>
    /// Реализация <see cref="IDateTimeProvider"/>
    /// </summary>
    public class DateTimeProvider : IDateTimeProvider
    {
        DateTimeOffset IDateTimeProvider.UtcNow => DateTimeOffset.UtcNow;
    }
}
