using Microsoft.Extensions.DependencyInjection;
using CarService.Repositories.Anchors;
using CarService.General;

namespace CarService.Repositories
{
    public static class ServiceExtensionsRepository
    {
        public static void RegistrationRepository(this IServiceCollection service)
        {
            //service.RegistrationOnInterface<IRepositoryAnchor>(ServiceLifetime.Scoped);
        }
    }
}
