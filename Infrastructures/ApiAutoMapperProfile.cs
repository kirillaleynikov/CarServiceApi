using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using CarService.Api.Models;
using CarService.Api.Models.Enums;
using CarService.Api.ModelsRequest.Client;
using CarService.Api.ModelsRequest.Employee;
using CarService.Api.ModelsRequest.Part;
using CarService.Api.ModelsRequest.Repair;
using CarService.Api.ModelsRequest.Room;
using CarService.Api.ModelsRequest.Service;
using CarService.Api.ModelsRequest.TimeTableItemRequest;
using CarService.Services.Contracts.Models;
using CarService.Services.Contracts.Models.Enums;
using CarService.Services.Contracts.ModelsRequest;

namespace CarService.Api.Infrastructures
{
    /// <summary>
    /// Профиль маппера АПИшки
    /// </summary>
    public class ApiAutoMapperProfile : Profile
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ApiAutoMapperProfile"/>
        /// </summary>
        public ApiAutoMapperProfile()
        {
            CreateMap<DocumentTypesModel, DocumentTypesResponse>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();
            CreateMap<EmployeeTypesModel, EmployeeTypesResponse>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();

            CreateMap<DisciplineModel, DisciplineResponse>(MemberList.Destination);
            CreateMap<DisciplineRequest, DisciplineModel>(MemberList.Destination);

            CreateMap<DocumentModel, DocumentResponse>(MemberList.Destination)
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Person != null
                    ? $"{x.Person.LastName} {x.Person.FirstName} {x.Person.Patronymic}"
                    : string.Empty))
                .ForMember(x => x.MobilePhone, opt => opt.MapFrom(x => x.Person != null
                    ? x.Person.Phone
                    : string.Empty))
                .ForMember(x => x.DocumentType, opt => opt.MapFrom(x => x.DocumentType));

            CreateMap<CreateDocumentRequest, DocumentRequestModel>(MemberList.Destination);
            CreateMap<DocumentRequest, DocumentRequestModel>(MemberList.Destination);

            CreateMap<EmployeeModel, EmployeeResponse>(MemberList.Destination)
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Person != null
                    ? $"{x.Person.LastName} {x.Person.FirstName} {x.Person.Patronymic}"
                    : string.Empty))
                .ForMember(x => x.MobilePhone, opt => opt.MapFrom(x => x.Person != null
                    ? x.Person.Phone
                    : string.Empty))
                .ForMember(x => x.EmployeeType, opt => opt.MapFrom(x => x.EmployeeType));

            CreateMap<CreateEmployeeRequest, EmployeeRequestModel>(MemberList.Destination);
            CreateMap<EmployeeRequest, EmployeeRequestModel>(MemberList.Destination);

            CreateMap<PersonModel, PersonResponse>(MemberList.Destination);
            CreateMap<CreatePersonRequest, PersonRequestModel>(MemberList.Destination);
            CreateMap<PersonRequest, PersonRequestModel>(MemberList.Destination);

            CreateMap<GroupModel, GroupResponse>(MemberList.Destination);
            CreateMap<CreateGroupRequest, GroupRequestModel>(MemberList.Destination);
            CreateMap<GroupRequest, GroupRequestModel>(MemberList.Destination);

            CreateMap<TimeTableItemModel, TimeTableItemResponse>(MemberList.Destination)
                .ForMember(x => x.NameDiscipline, opt => opt.MapFrom(x => x.Discipline!.Name))
                .ForMember(x => x.NameGroup, opt => opt.MapFrom(x => x.Group!.Name))
                .ForMember(x => x.TeacherName, opt => opt.MapFrom(x => $"{x.Teacher!.LastName} {x.Teacher.FirstName} {x.Teacher.Patronymic}"))
                .ForMember(x => x.Phone, opt => opt.MapFrom(x => x.Teacher!.Phone));
            CreateMap<CreateTimeTableItemRequest, TimeTableItemRequestModel>(MemberList.Destination);
            CreateMap<TimeTableItemRequest, TimeTableItemRequestModel>(MemberList.Destination);


        }
    }

}
