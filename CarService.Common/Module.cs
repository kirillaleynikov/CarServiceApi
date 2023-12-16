using Microsoft.Extensions.DependencyInjection;

namespace CarService.Common
{
    public abstract class Module
    {
        /// <summary>
        /// Создаёт зависимости
        /// </summary>
        public abstract void CreateModule(IServiceCollection service);
    }
}
