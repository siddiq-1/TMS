using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.MODEL;
using TMS.Data.Repositories.Interface;

namespace TMS.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskManagementSystemContext _tmsContext;
        public IRecurringJobRepository RecurringJobRepository { get; }
        public IReportTypeRepository ReportTypeRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public IScheduleReportRepository ScheduleReportRepository { get; }
        public ITaskAssignmentRepository TaskAssignmentRepository { get; }
        public ITaskCategoryRepository TaskCategoryRepository { get; }
        public ITaskRepository TaskRepository { get; }
        public ITaskStatusRepository TaskStatusRepository { get; }
        public IUserRepository UserRepository { get; }
        public IUserRoleMappingRepository UserRoleMappingRepository { get; }
        public ITaskPriorityRepository TaskPriorityRepository { get; }
        public IUserManagerRepository UserManagerRepository { get; }
        public IAppSettingRepository AppSettingRepository { get; }
        public IEmailTemplateRepository EmailTemplateRepository { get; }
        public UnitOfWork(TaskManagementSystemContext tmsContext,
            IRecurringJobRepository recurringJobRepository,
            IReportTypeRepository reportTypeRepository,
            IRoleRepository roleRepository,
            IScheduleReportRepository scheduleReportRepository,
            ITaskAssignmentRepository taskAssignmentRepository,
            ITaskCategoryRepository taskCategoryRepository,
            ITaskStatusRepository taskStatusRepository,
            ITaskRepository taskRepository,
            IUserRepository userRepository,
            IUserRoleMappingRepository userRoleMappingRepository,
            IUserManagerRepository userManagerRepository,
            ITaskPriorityRepository taskPriorityRepository,
            IAppSettingRepository appSettingRepository,
            IEmailTemplateRepository emailTemplateRepository)
        {
            _tmsContext = tmsContext;
            RecurringJobRepository = recurringJobRepository;
            ReportTypeRepository = reportTypeRepository;
            RoleRepository = roleRepository;
            ScheduleReportRepository = scheduleReportRepository;
            TaskAssignmentRepository = taskAssignmentRepository;
            TaskCategoryRepository = taskCategoryRepository;
            TaskStatusRepository = taskStatusRepository;
            TaskRepository = taskRepository;
            UserRepository = userRepository;
            UserRoleMappingRepository = userRoleMappingRepository;
            UserManagerRepository = userManagerRepository;
            UserManagerRepository = userManagerRepository;
            TaskPriorityRepository = taskPriorityRepository;
            AppSettingRepository = appSettingRepository;
            EmailTemplateRepository = emailTemplateRepository;
        }

        public async Task<int> CommitAsync()
        {
            return await _tmsContext.SaveChangesAsync();
        }
    }
}
