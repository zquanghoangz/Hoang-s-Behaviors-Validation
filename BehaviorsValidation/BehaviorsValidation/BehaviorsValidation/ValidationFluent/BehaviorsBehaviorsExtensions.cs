using System;
using System.Linq.Expressions;

namespace BehaviorsValidation.ValidationFluent
{
    public static class BehaviorsBehaviorsExtensions
    {
        public static FluentValidation When<T>
            (this T subject, Expression<Func<T, bool>> expressionProperty)
        {
            Func<T, bool> func = expressionProperty.Compile();
            bool value = func(subject);

            return new FluentValidation(value);
        }

        public static FluentValidation When<TValidator>
            (this ValidationCollected validationCollected,
                TValidator subject,
                Expression<Func<TValidator, bool>> expressionProperty)
        {
            Func<TValidator, bool> func = expressionProperty.Compile();
            bool value = func(subject);

            return new FluentValidation(validationCollected, value);
        }
    }
}