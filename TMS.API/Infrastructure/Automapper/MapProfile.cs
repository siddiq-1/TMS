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
            CreateMap<RecurringJobDto, RecurringJob>()
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<RoleDto, Role>()
              .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
              .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
              .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
              .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore())
              .ReverseMap();

            CreateMap<ReportTypeMasterDto, ReportTypeMaster>()
          .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
          .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
          .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
          .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore())
          .ReverseMap();

            CreateMap<ScheduleReportDto, ScheduleReport>()
           .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
          .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
          .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
          .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore())
          .ReverseMap();

            CreateMap<TaskDto, Task>()
           .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
          .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
          .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
          .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore())
          .ReverseMap();

            CreateMap<TaskAssignmentDto, TaskAssignment>()
           .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
          .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
          .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
          .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore())
          .ReverseMap();

            CreateMap<TaskCategoryDto, TaskCategory>()
           .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
          .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
          .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
          .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore())
          .ReverseMap();

            CreateMap<TaskStatusMasterDto, TaskStatusMaster>()
           .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
          .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
          .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
          .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore())
          .ReverseMap();

            CreateMap<User, UserDto>().ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.UserRoleMappings.Role.Name));
            CreateMap<UserDto, User>()
            //.ForMember(dest => dest.UserRoleMappings, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
             .ForMember(dest => dest.ModifyBy, opt => opt.Ignore())
             .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
              .ForMember(dest => dest.CreatedDate, opt => opt.Ignore());

            CreateMap<UserManagerMappingDto, UserManagerMapping>()
           .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
          .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
          .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
          .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore())
          .ReverseMap();

            CreateMap<UserRoleMapping, UserRoleMappingDto>()
           .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
          .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
          .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
          .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore())
          .ReverseMap();

            CreateMap<TaskPriorityTypesDto, TaskPriorityTypeMaster>()
            .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
            .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.ModifyBy, opt => opt.Ignore())
            .ReverseMap();

            CreateMap<AppSettingDto, AppSetting>()
        .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
        .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
        .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
        .ForMember(dest => dest.ModifyBy, opt => opt.Ignore())
        .ReverseMap();

            //PAGELIST DTO MAPPING
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

            CreateMap<PageResult<TaskPriorityTypeMaster>, PageResult<TaskPriorityTypesDto>>().ReverseMap().
                ForMember(dest => dest.List, opt => opt.MapFrom(src => src.List))
                .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.TotalRecords))
                .ForMember(dest => dest.List, opt => opt.UseDestinationValue());

            CreateMap<PageResult<AppSetting>, PageResult<AppSettingDto>>().ReverseMap().
              ForMember(dest => dest.List, opt => opt.MapFrom(src => src.List))
              .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.TotalRecords))
              .ForMember(dest => dest.List, opt => opt.UseDestinationValue());

        }
    }
}
