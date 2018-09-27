using System;
using System.Linq.Expressions;
using System.Reflection;

namespace DummyModels
{
    public class DummyBuilder<T> where T : IEntity, new()
    {
        private T model;

        public DummyBuilder()
        {
            model = new T();
        }
        
        public DummyBuilder<T> WithProperty<TProperty>(Expression<Func<T, TProperty>> propertyExp, TProperty value)
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