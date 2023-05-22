using FluentValidation;
using Microsoft.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

namespace TMS.API.Infrastructure.FluentValidationInstaller
{
    public abstract class ModelValidatorBase<T> : AbstractValidator<T>
    {
        protected virtual void ConfigureCommonRules()
        {
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                RuleFor(x => property.GetValue(x))
                    .NotEmpty().WithMessage($"{property.Name} is Required");
            }
        }
    }
}

