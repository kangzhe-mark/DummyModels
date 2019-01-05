using System;
using System.Dynamic;
using System.Reflection;
using FixtureBuilder.Models;

namespace FixtureBuilder
{
    public class DynamicFixtureBuilder<T> : DynamicObject where T: IEntity, new()
    {
        private T model;
        public DynamicFixtureBuilder()
        {
            model = new T();
        }
        public T Build()
        {
            return model;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            var propertyInfo = typeof(T).GetProperty(binder.Name, BindingFlags.Public | BindingFlags.Instance);
            if (propertyInfo.PropertyType.IsInstanceOfType(value))
            {
                propertyInfo.SetValue(model, value);
                return true;
            }

            if (propertyInfo.PropertyType.IsPrimitive && value.GetType().IsPrimitive)
            {
                propertyInfo.SetValue(model, Convert.ChangeType(value, propertyInfo.PropertyType));
                return true;
            }
            return base.TrySetMember(binder, value);
        }
    }
}