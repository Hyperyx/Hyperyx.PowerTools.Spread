using System;
using System.Linq;
using System.Linq.Expressions;

namespace Hyperyx.PowerTools.Spread
{
    /// <summary>
    /// Expression Extensions with handy methods.
    /// </summary>    
    internal static class ExpressionExtensions
    {
        /// <summary>
        /// This method will transform an expression into the location of a state slice.
        /// Also it filters out extension methods used in expression such as First().
        /// Which is necessary to specify in the expression when using lists.
        /// </summary>        
        public static string Slice<State, T>(this Expression<Func<State, T>> expr)
        {
            var stateSlice = string.Join(".", expr.ToString()
                .Split('.')
                .Where(x => !x.Contains("("))
                .Skip(1));

            return stateSlice;
        }
    }
}