using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Intent
{
    public static class Extensions
    {
        public static bool IsExcluded(this Assembly asm)
        {
            return asm.CustomAttributes.Any(a => a.AttributeType == typeof(ExcludeAttribute));
        }

        public static List<Type> SkipExcluded(this IEnumerable<Type> e)
        {
            return e.Where(i => i.GetCustomAttribute<ExcludeAttribute>() == null).ToList();
        }

        public static List<MethodInfo> SkipExcluded(this IEnumerable<MethodInfo> e)
        {
            return e.Where(i =>
            i.Name != nameof(object.ToString)
            && i.Name != nameof(object.GetType)
            && i.Name != nameof(object.GetHashCode)
            && i.Name != nameof(object.Equals)
            && i.GetCustomAttribute<ExcludeAttribute>() == null).ToList();
        }


    }
}
