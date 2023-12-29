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

            CreateMap<Client, ClientModel>(MemberList.Destination).ReverseMap();

            CreateMap<Employee, EmployeeModel>(MemberList.Destination).ReverseMap();

            CreateMap<Part, PartModel>(MemberList.Destination).ReverseMap();

            CreateMap<RepairTypes, RepairTypesModel>()
                            .ConvertUsingEnumMapping(opt => opt.MapByName())
                            .ReverseMap();


            CreateMap<RoomTypes, RoomTypesModel>()
                            .ConvertUsingEnumMapping(opt => opt.MapByName())
                            .ReverseMap();

            CreateMap<Room, RoomModel>(MemberList.Destination).ReverseMap();

            CreateMap<Service, ServiceModel>(MemberList.Destination).ReverseMap();

            CreateMap<Repair, RepairModel>(MemberList.Destination)
                .ForMember(x => x.Service, opt => opt.Ignore())
                .ForMember(x => x.PartToChange, opt => opt.Ignore())
                .ForMember(x => x.ClientName, opt => opt.Ignore())
                .ForMember(x => x.RoomNumber, opt => opt.Ignore()).ReverseMap();

            CreateMap<RepairRequestModel, Repair>(MemberList.Destination)
                .ForMember(x => x.Service, opt => opt.Ignore())
                .ForMember(x => x.PartToChange, opt => opt.Ignore())
                .ForMember(x => x.ClientName, opt => opt.Ignore())
                .ForMember(x => x.RoomNumber, opt => opt.Ignore())
                .ForMember(x => x.CreatedAt, opt => opt.Ignore())
                .ForMember(x => x.DeletedAt, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.UpdatedAt, opt => opt.Ignore())
                .ForMember(x => x.UpdatedBy, opt => opt.Ignore());

            Log.Information("Инициализирован Mapper в классе ServiceProfile");
        }
    }
}
