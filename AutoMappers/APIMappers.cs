using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using CarService.API.Models.CreateRequest;
using CarService.API.Models.Request;
using CarService.API.Models.Response;
using CarService.Context.Contracts.Enums;
using CarService.Models.Request;
using CarService.Services.Contracts.Models;
using CarService.Services.Contracts.Models.Enums;
using CarService.Services.Contracts.ModelsRequest;

namespace CarService.API.AutoMappers
{
    public class APIMappers:Profile
    {
        public APIMappers()
        {
            CreateMap<CreatePartRequest, ClientModel>(MemberList.Destination)
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<CreateEmployeeRequest, EmployeeModel>(MemberList.Destination)
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<CreatePartRequest, PartModel>(MemberList.Destination)
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<CreateRoomRequest, RoomModel>(MemberList.Destination)
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<CreateServiceRequest, ServiceModel>(MemberList.Destination)
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<PartRequest, PartModel>(MemberList.Destination);
            CreateMap<EmployeeRequest, EmployeeModel>(MemberList.Destination);
            CreateMap<PartRequest, PartModel>(MemberList.Destination);
            CreateMap<RoomRequest, RoomModel>(MemberList.Destination);
            CreateMap<ServiceRequest, ServiceModel>(MemberList.Destination);
            CreateMap<RepairRequest, RepairModel>(MemberList.Destination)
                .ForMember(x => x.Service, opt => opt.Ignore())
                .ForMember(x => x.PartToChange, opt => opt.Ignore())
                .ForMember(x => x.ClientName, opt => opt.Ignore())
                .ForMember(x => x.RoomNumber, opt => opt.Ignore());

            CreateMap<RepairTypes, RepairTypesModel>()
                            .ConvertUsingEnumMapping(opt => opt.MapByName())
                            .ReverseMap();


            CreateMap<RoomTypes, RoomTypesModel>()
                            .ConvertUsingEnumMapping(opt => opt.MapByName())
                            .ReverseMap();

            CreateMap<RepairRequest, RepairRequestModel>(MemberList.Destination);
            CreateMap<CreateRepairRequest, RepairRequestModel>(MemberList.Destination)
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<ClientModel, ClientResponse>(MemberList.Destination);
            CreateMap<EmployeeModel, EmployeeResponse>(MemberList.Destination);
            CreateMap<PartModel, PartResponse>(MemberList.Destination);
            CreateMap<RepairModel, RepairResponse>(MemberList.Destination);
            CreateMap<RoomModel, RoomResponse>(MemberList.Destination);
            CreateMap<ServiceModel, ServiceResponse>(MemberList.Destination);

        }
    }
}
