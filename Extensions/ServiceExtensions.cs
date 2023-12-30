using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using CarService.API.AutoMappers;
using CarService.Common.Entity;
using CarService.Common.Entity.InterfaceDB;
using CarService.Context;
using CarService.Repositories;
using CarService.Services;
using CarService.Services.Automappers;

namespace CarService.API.Extensions
{
    /// <summary>
    /// Расширения для <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Регистрирует все сервисы, репозитории и все что нужно для контекста
        /// </summary>
        public static void RegistrationSRC(this IServiceCollection services)
        {
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();
            services.AddTransient<IDbWriterContext, DbWriterContext>();
            //services.RegistrationService();
            //services.RegistrationRepository();
            //services.RegistrationContext();
            services.AddAutoMapper(typeof(APIMappers), typeof(ServiceProfile));
        }

        /// <summary>
        /// Включает фильтры и ставит шрифт на перечесления
        /// </summary>
        /// <param name="services"></param>
        public static void RegistrationControllers(this IServiceCollection services)
        {
            services.AddControllers(x =>
            {
                x.Filters.Add<CarServiceExceptionFilter>();
            })
                .AddNewtonsoftJson(o =>
                {
                    o.SerializerSettings.Converters.Add(new StringEnumConverter
                    {
                        CamelCaseText = false
                    });
                });
        }

        /// <summary>
        /// Настройки свагера
        /// </summary>
        public static void RegistrationSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("Client", new OpenApiInfo { Title = "Клиенты", Version = "v1" });
                c.SwaggerDoc("Employee", new OpenApiInfo { Title = "Сотрудники", Version = "v1" });
                c.SwaggerDoc("Part", new OpenApiInfo { Title = "Запчасти", Version = "v1" });
                c.SwaggerDoc("Repair", new OpenApiInfo { Title = "Ремонты", Version = "v1" });
                c.SwaggerDoc("Room", new OpenApiInfo { Title = "Помещения", Version = "v1" });
                c.SwaggerDoc("Service", new OpenApiInfo { Title = "Услуги", Version = "v1" });


                var filePath = Path.Combine(AppContext.BaseDirectory, "CarService.API.xml");
                c.IncludeXmlComments(filePath);
            });
        }

        /// <summary>
        /// Настройки свагера
        /// </summary>
        public static void CustomizeSwaggerUI(this WebApplication web)
        {
            web.UseSwagger();
            web.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("Client/swagger.json", "Клиенты");
                x.SwaggerEndpoint("Employees/swagger.json", "Сотрудники");
                x.SwaggerEndpoint("Part/swagger.json", "Запчасти");
                x.SwaggerEndpoint("Repair/swagger.json", "Ремонты");
                x.SwaggerEndpoint("Room/swagger.json", "Комнаты");
                x.SwaggerEndpoint("Service/swagger.json", "Услуги");
            });
        }
    }
}
