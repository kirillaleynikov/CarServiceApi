using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using CarService.Common;
using CarService.Common.Entity.InterfaceDB;
using CarService.Context.Contracts;

namespace CarService.Context
{
    public class ContextModule : Module
    {
        public override void CreateModule(IServiceCollection service)
        {
            service.TryAddScoped<ICarServiceContext>(provider => provider.GetRequiredService<CarServiceContext>());
            service.TryAddScoped<IDbRead>(provider => provider.GetRequiredService<CarServiceContext>());
            service.TryAddScoped<IDbWriter>(provider => provider.GetRequiredService<CarServiceContext>());
            service.TryAddScoped<IUnitOfWork>(provider => provider.GetRequiredService<CarServiceContext>());
        }
    }
}
