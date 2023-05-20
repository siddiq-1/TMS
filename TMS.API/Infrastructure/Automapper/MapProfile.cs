using AutoMapper;
using TMS.Model;
using TMS.ModelDTO;
using TMS.ModelDTO.Task;
using TMS.ModelDTO.User;
using TMS.Utility;
using Task = TMS.Model.Task;

namespace TMS.API.Infrastructure.Automapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<RecurringJob, RecurringJobDto>().ReverseMap();
            CreateMap<ReportTypeMaster, ReportTypeMasterDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<ScheduleReport, ScheduleReportDto>().ReverseMap();
            CreateMap<Task, TaskDto>().ReverseMap();
            CreateMap<TaskAssignment, TaskAssignmentDto>().ReverseMap();
            CreateMap<TaskCategory, TaskCategoryDto>().ReverseMap();
            CreateMap<TaskStatusMaster, TaskStatusMasterDto>().ReverseMap();
            CreateMap<User, UserDto>().ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.UserRoleMappings.Role.Name)).ReverseMap();
            CreateMap<UserManagerMapping, UserManagerMappingDto>().ReverseMap();
            CreateMap<UserRoleMapping, UserRoleMappingDto>().ReverseMap();

            CreateMap<PageResult<User>, PageResult<UserDto>>().ReverseMap().
                ForMember(dest => dest.List, opt => opt.MapFrom(src => src.List))
                .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.TotalRecords))
                .ForMember(dest => dest.List, opt => opt.UseDestinationValue());
            CreateMap<PageResult<RecurringJob>, PageResult<RecurringJobDto>>().ReverseMap().
               ForMember(dest => dest.List, opt => opt.MapFrom(src => src.List))
               .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.TotalRecords))
               .ForMember(dest => dest.List, opt => opt.UseDestinationValue());
            CreateMap<PageResult<ReportTypeMaster>, PageResult<ReportTypeMasterDto>>().ReverseMap().
               ForMember(dest => dest.List, opt => opt.MapFrom(src => src.List))
               .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.TotalRecords))
               .ForMember(dest => dest.List, opt => opt.UseDestinationValue());
            CreateMap<PageResult<TaskAssignment>, PageResult<TaskAssignmentDto>>().ReverseMap().
               ForMember(dest => dest.List, opt => opt.MapFrom(src => src.List))
               .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.TotalRecords))
               .ForMember(dest => dest.List, opt => opt.UseDestinationValue());
            CreateMap<PageResult<Role>, PageResult<RoleDto>>().ReverseMap().
               ForMember(dest => dest.List, opt => opt.MapFrom(src => src.List))
               .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.TotalRecords))
               .ForMember(dest => dest.List, opt => opt.UseDestinationValue());
            CreateMap<PageResult<Task>, PageResult<TaskDto>>().ReverseMap().
                ForMember(dest => dest.List, opt => opt.MapFrom(src => src.List))
                .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.TotalRecords))
                .ForMember(dest => dest.List, opt => opt.UseDestinationValue()); 
            CreateMap<PageResult<UserRoleMapping>, PageResult<UserRoleMappingDto>>().ReverseMap().
                ForMember(dest => dest.List, opt => opt.MapFrom(src => src.List))
                .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.TotalRecords))
                .ForMember(dest => dest.List, opt => opt.UseDestinationValue()); 
            CreateMap<PageResult<UserManagerMapping>, PageResult<UserManagerMappingDto>>().ReverseMap().
                ForMember(dest => dest.List, opt => opt.MapFrom(src => src.List))
                .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.TotalRecords))
                .ForMember(dest => dest.List, opt => opt.UseDestinationValue());
            CreateMap<PageResult<TaskCategory>, PageResult<TaskCategoryDto>>().ReverseMap().
                ForMember(dest => dest.List, opt => opt.MapFrom(src => src.List))
                .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.TotalRecords))
                .ForMember(dest => dest.List, opt => opt.UseDestinationValue()); 
            CreateMap<PageResult<ScheduleReport>, PageResult<ScheduleReportDto>>().ReverseMap().
                ForMember(dest => dest.List, opt => opt.MapFrom(src => src.List))
                .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.TotalRecords))
                .ForMember(dest => dest.List, opt => opt.UseDestinationValue()); 
            CreateMap<PageResult<TaskStatusMaster>, PageResult<TaskStatusMasterDto>>().ReverseMap().
                ForMember(dest => dest.List, opt => opt.MapFrom(src => src.List))
                .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.TotalRecords))
                .ForMember(dest => dest.List, opt => opt.UseDestinationValue());
        }
    }
}
