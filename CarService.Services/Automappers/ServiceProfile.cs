using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using Serilog;
using CarService.Context.Contracts.Enums;
using CarService.Context.Contracts.Models;
using CarService.Services.Contracts.Models;
using CarService.Services.Contracts.Models.Enums;

namespace CarService.Services.Automappers
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Client, ClientModel>(MemberList.Destination);

            CreateMap<Employee, EmployeeModel>(MemberList.Destination);

            CreateMap<Part, PartModel>(MemberList.Destination);

            CreateMap<RepairTypes, RepairTypesModel>()
                            .ConvertUsingEnumMapping(opt => opt.MapByName())
                            .ReverseMap();

            CreateMap<RoomTypes, RoomTypesModel>()
                            .ConvertUsingEnumMapping(opt => opt.MapByName())
                            .ReverseMap();

            CreateMap<Service, ServiceModel>(MemberList.Destination);

            Log.Information("Инициализирован Mapper в классе ServiceProfile");
        }
    }
}
