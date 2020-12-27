using System.Linq;
using System.Reflection;

namespace Hyperyx.PowerTools.Spread
{
    /// <summary>
    /// ReflectionExtensions to Get or Set state slices.
    /// </summary>
    internal static class ReflectionExtensions
    {
        /// <summary>
        /// Reducers should only be allowed to update the state. 
        /// Manipulating the state manually is not nice :( So don't do it :)
        /// </summary>
        /// <param name="compoundProperty">Path to the state slice.</param>
        /// <param name="target">The store which contains the state.</param>
        /// <param name="value">Set the new value for the state</param>
        public static void Set(string compoundProperty, object target, object value)
        {
            var o = FindProperty(compoundProperty, target);
            if (o.property != null) o.property.SetValue(o.target, value, null);
        }

        /// <summary>
        /// Returns a tuple for Get/Set of the state slice.
        /// </summary>
        /// <param name="compoundProperty">Path to the state slice.</param>
        /// <param name="target">The store which contains the state.</param>
        /// <returns>Returns a tuple for Get/Set.</returns>
        private static (PropertyInfo property, object target) FindProperty(string compoundProperty, object target)
        {
            var properties = compoundProperty.Split('.');
            for (int i = 0; i < properties.Length - 1; i++)
            {
                var property = target?.GetType()?.GetProperty(properties[i]);
                if (property == null) return (null, null);

                target = property.GetValue(target, null);
            }
            return (target.GetType().GetProperty(properties.Last()), target);
        }
    }
}