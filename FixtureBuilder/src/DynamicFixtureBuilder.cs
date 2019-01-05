using System;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace FixtureBuilder
{
    class DynamicFixtureBuilder<T> : DynamicObject where T: IEntity, new()
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
            if (propertyInfo.PropertyType == value.GetType())
            {
                propertyInfo.SetValue(model, value);
            }
            else
            {
                propertyInfo.SetValue(model, Convert.ChangeType(value, propertyInfo.PropertyType));
            }
            return true;
        }
    }
}