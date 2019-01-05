using System;
using System.Linq.Expressions;
using System.Reflection;
using FixtureBuilder.Models;

namespace FixtureBuilder
{
    public class FixtureBuilder<T> where T : IEntity, new()
    {
        private T model;

        public FixtureBuilder()
        {
            model = new T();
        }
        
        public FixtureBuilder<T> WithProperty<TProperty>(Expression<Func<T, TProperty>> propertyExp, TProperty value)
        {
            if (propertyExp.Body is MemberExpression member && member.Member is PropertyInfo propertyInfo)
            {
                propertyInfo.SetValue(model, value);
            }

            return this;
        }

        public T Build()
        {
            return model;
        }

    }
}