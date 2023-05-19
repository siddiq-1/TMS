using FluentValidation;
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
        }
    }
}
