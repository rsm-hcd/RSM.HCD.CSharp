using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AndcultureCode.CSharp.Extensions
{
    /// <summary>
    /// Extensions for Assembly
    /// </summary>
    public static class AssemblyExtension
    {
        /// <summary>
        /// Get loadable from give assembly
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetSafetlyTypes(this Assembly assembly)
        {
            if(assembly == null)
                return Enumerable.Empty<Type>();
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
            catch (Exception)
            {
                return Enumerable.Empty<Type>();
            }
        }
    }
}
