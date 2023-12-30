using Microsoft.Extensions.DependencyInjection;
using CarService.General;
using CarService.Services.Anchors;

namespace CarService.Services
{
    public static class ServiceExtensionsService  /// <summary>
                                                  /// Регистрация всех сервисов и валидатора
    {                                          /// </summary>
        public static void RegistrationService(this IServiceCollection service)
        {
            //service.RegistrationOnInterface<IServiceAnhor>(ServiceLifetime.Scoped);
            service.AddTransient<IServiceValidatorService, ServicesValidatorService>();
        }
    }
}

