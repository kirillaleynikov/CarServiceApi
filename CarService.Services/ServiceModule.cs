using Microsoft.Extensions.DependencyInjection;
using CarService.Common;
using CarService.Services.Automappers;
using CarService.Shared;

namespace CarService.Services
{
    public class ServiceModule : Module
    {
        public override void CreateModule(IServiceCollection service)
        {
            service.AssemblyInterfaceAssignableTo<IServiceAnchor>(ServiceLifetime.Scoped);
            service.RegisterAutoMapperProfile<ServiceProfile>();
        }
    }
}
