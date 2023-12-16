using CarService.Shared;
using Microsoft.Extensions.DependencyInjection;
using CarService.Common;

namespace CarService.Repositories
{
    public class RepositoryModule : Module
    {
        public override void CreateModule(IServiceCollection service)
        {
            service.AssemblyInterfaceAssignableTo<IRepositoryAnchor>(ServiceLifetime.Scoped);
        }
    }
}
