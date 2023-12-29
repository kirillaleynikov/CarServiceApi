using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using CarService.Common.Entity.InterfaceDB;
using CarService.Context.Contracts;

namespace CarService.Context
{
    /// <summary>
    /// Методы пасширения для <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServiceExtensionsContext
    {
        /// <summary>
        /// Регистрирует все что связано с контекстом
        /// </summary>
        /// <param name="service"></param>
        public static void RegistrationContext(this IServiceCollection service)
        {
            service.TryAddScoped<ICarServiceContext>(provider => provider.GetRequiredService<CarServiceContext>());
            service.TryAddScoped<IDbRead>(provider => provider.GetRequiredService<CarServiceContext>());
            service.TryAddScoped<IDbWriter>(provider => provider.GetRequiredService<CarServiceContext>());
            service.TryAddScoped<IUnitOfWork>(provider => provider.GetRequiredService<CarServiceContext>());
        }
    }
}
