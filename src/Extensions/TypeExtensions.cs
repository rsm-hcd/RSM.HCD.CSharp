using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RSM.HCD.CSharp.Extensions
{
    /// <summary>
    /// Extensions for Type
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Get the PropertyInfo for specified property,
        /// if it exists on the type and is public,
        /// otherwise returns null.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="propertyName"></param>
        /// <returns>The PropertyInfo for the property, if it exists and is public, null otherwise.</returns>
        public static PropertyInfo GetPublicPropertyInfo(this Type type, string propertyName)
        {
            if (!type.HasPublicProperty(propertyName))
            {
                return null;
            }

            return type.GetProperty(propertyName);
        }

        /// <summary>
        /// Get the value of a property specified by propertyName,
        /// if it exists on the object and is public.
        /// If no such public property exists, returns null.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="propertyName"></param>
        /// <returns>The property value, if it exists and is public, null otherwise.</returns>
        public static object GetPublicPropertyValue(this object src, string propertyName)
        {
            if (src == null)
            {
                return null;
            }

            if (!src.GetType().HasPublicProperty(propertyName))
            {
                return null;
            }

            return src.GetType().GetProperty(propertyName)?.GetValue(src);
        }

        /// <summary>
        /// Get the value of a property specified by propertyName,
        /// if it exists on the object and is public, casted to type T.
        /// If no such property exists, returns null.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="propertyName"></param>
        /// <returns>The property value, if it exists, null otherwise.</returns>
        public static T GetPublicPropertyValue<T>(this object src, string propertyName) =>
            (T)src.GetPublicPropertyValue(propertyName);

        /// <summary>
        /// Retrieve all constant values for given type whose value matches type T
        /// </summary>
        public static List<T> GetPublicConstantValues<T>(this Type type) =>
            type.GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(f => f.IsLiteral && !f.IsInitOnly && f.FieldType == typeof(T))
                .Select(f => (T)f.GetRawConstantValue())
                .ToList();

        /// <summary>
        /// Returns the name the underlying type of any object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetTypeName(this object obj) => GetTypeName(obj?.GetType());

        /// <summary>
        /// Returns the full name of the type as well as the assembly qualified name
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetTypeName(this Type type)
        {
            if (type == null)
            {
                return null;
            }

            return type.FullName + ", " + type.AssemblyQualifiedName;
        }

        /// <summary>
        /// Checks whether a property specified by propertyName exists
        /// on the specified type.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="propertyName"></param>
        /// <returns>true if type has property with specified name, false otherwise</returns>
        public static bool HasPublicProperty(this Type type, string propertyName) =>
            type.GetProperties().Any(property => property.Name == propertyName);

        /// <summary>
        /// Filters the provided list of types to only those that are
        /// decorated with the TAttribute attribute at the class level.
        /// </summary>
        public static List<Type> WhereWithAttribute<TAttribute>(this IEnumerable<Type> types) where TAttribute : Attribute
            => types?.Where(t => t.GetCustomAttribute<TAttribute>() != null).Distinct().ToList();

        /// <summary>
        /// Filters the provided list of types to only those that aren't
        /// decorated with the TAttribute attribute at the class level.
        /// </summary>
        public static List<Type> WhereWithoutAttribute<TAttribute>(this IEnumerable<Type> types) where TAttribute : Attribute
            => types?.Where(t => t.GetCustomAttribute<TAttribute>() == null).Distinct().ToList();
    }
}
