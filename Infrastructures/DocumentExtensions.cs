using Microsoft.OpenApi.Models;

namespace CarService.Api.Infrastructures
{
    static internal class DocumentExtensions
    {
        public static void GetSwaggerDocument(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("Client", new OpenApiInfo { Title = "Сущность клиента", Version = "v1" });
                c.SwaggerDoc("Employee", new OpenApiInfo { Title = "Сущность сотрудника", Version = "v1" });
                c.SwaggerDoc("Part", new OpenApiInfo { Title = "Сущность запчасти", Version = "v1" });
                c.SwaggerDoc("Repair", new OpenApiInfo { Title = "Сущность ремонта", Version = "v1" });
                c.SwaggerDoc("Room", new OpenApiInfo { Title = "Сущность помещения", Version = "v1" });
                c.SwaggerDoc("Service", new OpenApiInfo { Title = "Сущность услуги", Version = "v1" });

                var filePath = Path.Combine(AppContext.BaseDirectory, "CarService.Api.xml");
                c.IncludeXmlComments(filePath);
            });
        }

        public static void GetSwaggerDocumentUI(this WebApplication app)
        {
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("Client/swagger.json", "Клиенты");
                x.SwaggerEndpoint("Employee/swagger.json", "Сотрудники");
                x.SwaggerEndpoint("Part/swagger.json", "Запчасти");
                x.SwaggerEndpoint("Repair/swagger.json", "Ремонты");
                x.SwaggerEndpoint("Room/swagger.json", "Помещения");
                x.SwaggerEndpoint("Service/swagger.json", "Услуги");
            });
        }
    }
}
