using AutoMapper;
using TMS.Model;
using TMS.ModelDTO;
using TMS.ModelDTO.Task;
using TMS.ModelDTO.User;
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
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserManagerMapping, UserManagerMappingDto>().ReverseMap();
            CreateMap<UserRoleMapping, UserRoleMappingDto>().ReverseMap();
        }
    }
}
