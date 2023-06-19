using FluentValidation;
using System.Globalization;
using System.Linq.Expressions;
using TMS.ModelDTO;
using TMS.ModelDTO.Task;
using TMS.ModelDTO.User;

namespace TMS.API.Infrastructure.FluentValidationInstaller
{
    public class RoleValidator : ModelValidatorBase<RoleDto>
    {
        public RoleValidator()
        {
            ConfigureCommonRules();

            RuleFor(dto => dto.Name)
               .MinimumLength(4).WithMessage("Name must be atleast 4 characters long.")
               .MaximumLength(20).WithMessage("Name must be below 20 characters")
               .NotNull().WithMessage("Name must contain any Value");

            RuleFor(dto => dto.IsActive)
                .NotNull().WithMessage("Must contain value");
        }
    }
    public class UserValidator : ModelValidatorBase<UserDto>
    {
        public UserValidator()
        {
            ConfigureCommonRules();

            RuleFor(dto => dto.UserName)
               .MinimumLength(4).WithMessage("Name must be atleast 4 characters long.")
               .MaximumLength(20).WithMessage("Name must be below 20 characters")
               .NotNull().WithMessage("Name must contain any Value");

            RuleFor(dto => dto.Password)
                .Matches("^(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$")
                .WithMessage("The password must contain at least one uppercase letter, one numeric digit, and one special character.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long");

            RuleFor(dto => dto.Email)
                .Matches(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")
                .WithMessage("Invalid Email-Address")
                .NotNull().WithMessage("Email must contain value");

            RuleFor(dto => dto.ContactNo)
                .MaximumLength(20).WithMessage("Invalid Mobile-No")
                .NotNull().WithMessage("Mobile Number must contain value");

            RuleFor(dto => dto.FirstName)
                .NotNull().WithMessage("First Name must contain value");

            RuleFor(dto => dto.DateOfBirth)
                .NotNull().WithMessage("DateOfBirth must contain value");

            RuleFor(dto => dto.IsActive)
                .NotNull().WithMessage("Must contain value");
        }
    }
    public class RecurringJobValidator : ModelValidatorBase<RecurringJobDto>
    {
        public RecurringJobValidator()
        {
            ConfigureCommonRules();

            RuleFor(dto => dto.Name)
               .MinimumLength(4).WithMessage("Name must be atleast 4 characters long.")
               .MaximumLength(20).WithMessage("Name must be below 20 characters")
               .NotNull().WithMessage("Name must contain any Value");

            RuleFor(dto => dto.IsActive)
                .NotNull().WithMessage("Must contain value");
        }
    }
    public class ReportTypeValidator : ModelValidatorBase<ReportTypeMasterDto>
    {
        public ReportTypeValidator()
        {
            ConfigureCommonRules();

            RuleFor(dto => dto.Name)
               .MinimumLength(4).WithMessage("Name must be atleast 4 characters long.")
               .MaximumLength(20).WithMessage("Name must be below 20 characters")
               .NotNull().WithMessage("Name must contain any Value");

            RuleFor(dto => dto.IsActive)
                .NotNull().WithMessage("Must contain value");
        }
    }
    public class ScheduleReportValidator : ModelValidatorBase<ScheduleReportDto>
    {
        public ScheduleReportValidator()
        {
            ConfigureCommonRules();


            RuleFor(dto => dto.ScheduleTime)
           .NotNull().WithMessage("ScheduleTime must contain any Value");

            RuleFor(dto => dto.UserId)
           .NotNull().WithMessage("UserId must contain any Value");

        }
    }
    public class TaskValidator : ModelValidatorBase<TaskDto>
    {
        public TaskValidator()
        {
            ConfigureCommonRules();

            RuleFor(dto => dto.Title)
               .MinimumLength(4).WithMessage("Title must be atleast 4 characters long.")
               .MaximumLength(200).WithMessage("Title must be below 200 characters")
               .NotNull().WithMessage("Title must contain any Value");

            RuleFor(dto => dto.Description)
                .MinimumLength(10).WithMessage("Description must be atleast 10 characters long.")
                .MaximumLength(1000).WithMessage("Description must be below 1000 characters")
                .NotNull().WithMessage("Description must contain value");

            RuleFor(dto => dto.IsActive)
                .NotNull().WithMessage("Must contain value");
        }
    }
    public class TaskAssignmentValidator : ModelValidatorBase<TaskAssignmentDto>
    {
        public TaskAssignmentValidator()
        {
            ConfigureCommonRules();

            RuleFor(dto => dto.StatusId)
                .NotNull().WithMessage("StatusId must contain any Value");

            RuleFor(dto => dto.TaskId)
           .NotNull().WithMessage("TaskId must contain any Value");

            RuleFor(dto => dto.AssignedBy)
           .NotNull().WithMessage("AssignedBy must contain any Value");

            RuleFor(dto => dto.AssignedTo)
           .NotNull().WithMessage("AssignedTo must contain any Value");

            RuleFor(dto => dto.CategoryId)
           .NotNull().WithMessage("CategoryId must contain any Value");

            RuleFor(dto => dto.IsActive)
                .NotNull().WithMessage("Must contain value");
        }
    }

    public class TaskCategoryValidator : ModelValidatorBase<TaskCategoryDto>
    {
        public TaskCategoryValidator()
        {
            ConfigureCommonRules();

            RuleFor(dto => dto.Name)
               .MinimumLength(4).WithMessage("Title must be atleast 4 characters long.")
               .MaximumLength(50).WithMessage("Title must be below 50 characters")
               .NotNull().WithMessage("Title must contain any Value");

            RuleFor(dto => dto.IsActive)
                .NotNull().WithMessage("Must contain value");
        }
    }

    public class TaskStatusValidator : ModelValidatorBase<TaskStatusMasterDto>
    {
        public TaskStatusValidator()
        {
            ConfigureCommonRules();

            RuleFor(dto => dto.Status)
               .MinimumLength(4).WithMessage("Title must be atleast 4 characters long.")
               .MaximumLength(50).WithMessage("Title must be below 50 characters")
               .NotNull().WithMessage("Title must contain any Value");

            RuleFor(dto => dto.IsActive)
                .NotNull().WithMessage("Must contain value");
        }
    }
    public class UserManagerValidator : ModelValidatorBase<UserManagerMappingDto>
    {
        public UserManagerValidator()
        {
            ConfigureCommonRules();

            RuleFor(dto => dto.UserId)
            .NotNull().WithMessage("UserId must contain any Value");

            RuleFor(dto => dto.ManagerId)
           .NotNull().WithMessage("ManagerId must contain any Value");

            RuleFor(dto => dto.IsActive)
            .NotNull().WithMessage("Must contain value");
        }
    }
    public class UserRoleMappingValidator : ModelValidatorBase<UserRoleMappingDto>
    {
        public UserRoleMappingValidator()
        {
            ConfigureCommonRules();

            RuleFor(dto => dto.UserId)
            .NotNull().WithMessage("UserId must contain any Value");

            RuleFor(dto => dto.RoleId)
           .NotNull().WithMessage("RoleId must contain any Value");

            RuleFor(dto => dto.IsActive)
           .NotNull().WithMessage("Must contain value");
        }
    }
    public class TaskInfoDataValidator : ModelValidatorBase<TaskInfoData>
    {
        public TaskInfoDataValidator()
        {
            ConfigureCommonRules();
            RuleFor(dto => dto.Title)
             .MinimumLength(4).WithMessage("Title must be atleast 4 characters long.")
             .MaximumLength(200).WithMessage("Title must be below 200 characters")
             .NotNull().WithMessage("Title must contain any Value");

            RuleFor(dto => dto.Description)
                .MinimumLength(10).WithMessage("Description must be atleast 10 characters long.")
                .MaximumLength(1000).WithMessage("Description must be below 1000 characters")
                .NotNull().WithMessage("Description must contain value");

            RuleFor(dto => dto.PriorityId)
                .NotNull().WithMessage("PriorityID Must contain value");

            RuleFor(dto => dto.StatusId)
            .NotNull().WithMessage("StatusIds must contain any Value");

            RuleFor(dto => dto.CategoryId)
           .NotNull().WithMessage("CategoryId must contain any Value");

            RuleFor(dto => dto.DueDate)
                .NotNull().WithMessage("DueDate must contain value");
        }
    }
    public class LoginValidator : ModelValidatorBase<LoginDto>
    {
        public LoginValidator()
        {
            ConfigureCommonRules();

            RuleFor(dto => dto.UserName)
              .MinimumLength(4).WithMessage("Name must be atleast 4 characters long.")
              .MaximumLength(20).WithMessage("Name must be below 20 characters")
              .NotNull().WithMessage("Name must contain any Value");

            RuleFor(dto => dto.Password)
                .Matches("^(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$")
                .WithMessage("The password must contain at least one uppercase letter, one numeric digit, and one special character.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long");
        }
    }
}
