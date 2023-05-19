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
                RuleFor(GetPropertyExpression(property))
                    .NotEmpty().WithMessage($"{property.Name} is Required");
            }
        }
        private Expression<Func<T, object>> GetPropertyExpression(PropertyInfo property)
        {
            var parameter = Expression.Parameter(typeof(T));
            var propertyAccess = Expression.Property(parameter, property);
            return Expression.Lambda<Func<T, object>>(propertyAccess, parameter);
        }
    }
}

