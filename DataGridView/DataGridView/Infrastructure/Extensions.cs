using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataGridView.Infrastructure
{
    public static class Extensions
    {

        public static void AddBinding<TControl, TSource>(
            this TControl control,
            Expression<Func<TControl, object>> targetMember,
            TSource source,
            Expression<Func<TSource, object>> sourceMember,
            ErrorProvider? errorProvider = null)
            where TControl : Control
            where TSource : class
        {
            var sourceMemberName = GetPropertyName(sourceMember);
            var binding = new Binding(GetPropertyName(targetMember), source, sourceMemberName)
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            control.DataBindings.Add(binding);

            if (errorProvider != null)
            {
                var sourcePropertyInfo = source.GetType().GetProperty(sourceMemberName);
                var validationAttributes = sourcePropertyInfo?.GetCustomAttributes<ValidationAttribute>();
                if (validationAttributes?.Any() == true)
                {
                    control.Validating += (o, args) =>
                    {
                        var context = new ValidationContext(source)
                        {
                            MemberName = sourceMemberName
                        };
                        var results = new List<ValidationResult>();
                        errorProvider.SetError(control, string.Empty);

                        var propertyValue = sourcePropertyInfo.GetValue(source);
                        bool isValid = Validator.TryValidateProperty(propertyValue, context, results);

                        if (!isValid)
                        {
                            errorProvider.SetError(control, results.First().ErrorMessage);
                        }
                        else
                        {
                            errorProvider.SetError(control, string.Empty);
                        }
                    };
                }
            }
        }


        static string GetPropertyName<TType>(Expression<Func<TType, object>> expression)
        {
            Expression body = expression.Body;
            if (body.NodeType == ExpressionType.Convert)
            {
                body = ((UnaryExpression)body).Operand;
            }

            if (body is MemberExpression memberExpression)
            {
                return memberExpression.Member.Name;
            }

            throw new ArgumentException("Espression must be a property access", nameof(expression));
        }

    }
}
