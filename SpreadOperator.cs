using System;
using System.Linq.Expressions;
using Force.DeepCloner;

namespace Hyperyx.PowerTools.Spread
{
    /// <summary>
    /// SpreadOperator extensions
    /// </summary>
    public static class SpreadOperator
    {
        /// <summary>
        /// Spreads all the values into a deep cloned object.
        /// Updates the cloned object property with the value set.
        /// </summary>
        /// <param name="target">Target is the the object to clone.</param>
        /// <param name="property">The property to update within the clone.</param>
        /// <param name="value">The value to set for the property.</param>
        /// <typeparam name="T">Type of the target object.</typeparam>
        /// <typeparam name="P">Type of the property</typeparam>
        /// <returns></returns>
        public static T Spread<T, P>(this T target, Expression<Func<T, P>> property, P value)
        {
            var clone = target.DeepClone();
            var slice = property.Slice();

            ReflectionExtensions.Set(slice, clone, value);

            return clone;
        }
    }
}