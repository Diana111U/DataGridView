using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

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
            var targetPropertyName = GetPropertyName(targetMember);
            var sourcePropertyName = GetPropertyName(sourceMember);

            // Удаляем старый биндинг с этого свойства контрола (если есть)
            var existing = control.DataBindings.Cast<Binding>()
                .FirstOrDefault(b => b.PropertyName == targetPropertyName);
            if (existing != null)
            {
                control.DataBindings.Remove(existing);
            }

            // Создаем новый биндинг
            var binding = new Binding(targetPropertyName, source, sourcePropertyName)
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            control.DataBindings.Add(binding);

            // Валидация через ErrorProvider (если задан)
            if (errorProvider != null)
            {
                var sourcePropertyInfo = source.GetType().GetProperty(sourcePropertyName);
                var validationAttributes = sourcePropertyInfo?.GetCustomAttributes<ValidationAttribute>();

                if (validationAttributes?.Any() == true)
                {
                    control.Validating += (o, args) =>
                    {
                        var context = new ValidationContext(source)
                        {
                            MemberName = sourcePropertyName
                        };
                        var results = new List<ValidationResult>();
                        errorProvider.SetError(control, string.Empty);

                        // Проверка значения свойства
                        var propertyValue = sourcePropertyInfo.GetValue(source);
                        bool isValid = Validator.TryValidateProperty(propertyValue, context, results);

                        if (!isValid)
                        {
                            errorProvider.SetError(control, results.First().ErrorMessage);
                            if (args is System.ComponentModel.CancelEventArgs cancelArgs)
                                cancelArgs.Cancel = true; // Не уходим с поля, если ошибка
                        }
                    };
                }
            }
        }

        // Вспомогательный метод для получения имени свойства из лямбда-выражения
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

            throw new ArgumentException("Expression must be a property access", nameof(expression));
        }
    }
}