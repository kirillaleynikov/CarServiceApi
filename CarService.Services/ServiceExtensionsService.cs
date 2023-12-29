using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using CarService.General;
using CarService.Repositories.Contracts.ReadRepositoriesContracts;
using CarService.Services.Anchors;
using CarService.Services.Contracts.Exceptions;
using CarService.Services.Contracts.Models;
using CarService.Services.Validator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Services
{
    public static class ServiceExtensionsService  /// <summary>
                                                  /// Регистрация всех сервисов и валидатора
    {                                          /// </summary>
        public static void RegistrationService(this IServiceCollection service)
        {
            service.RegistrationOnInterface<IServiceAnhor>(ServiceLifetime.Scoped);
            service.AddTransient<IServiceValidatorService, ServicesValidatorService>();
        }
    }
}

