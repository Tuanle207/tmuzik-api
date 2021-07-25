using System;
using System.Linq;
using System.Reflection;

namespace Tmuzik.Infrastructure.Models
{
    public static class EntityExtesions
    {
        public static void UpdateWith<T, TUpdate>(this T obj, TUpdate updateObj) where T : Entity
		{
			var props = obj.GetType().GetProperties();
			var updateProps = updateObj.GetType().GetProperties();
			foreach (PropertyInfo updateProp in updateProps)
			{
				var prop = props.FirstOrDefault(
					x => x.Name == updateProp.Name
					&& CompareType(x.PropertyType, updateProp.PropertyType));
				if (prop == default)
				{
					continue;
				}
				var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
				if (type == default)
				{
					continue;
				}
				var value = updateProp.GetValue(updateObj, null);
				prop.SetValue(obj, value, null);
			}
		}

		private static bool CompareType(Type left, Type right)
		{
			var l = Nullable.GetUnderlyingType(left) ?? left;
			var r = Nullable.GetUnderlyingType(right) ?? right;
			if (l == null || r == null)
			{
				return false;
			}
			return l.Equals(r);
		}
    }
}