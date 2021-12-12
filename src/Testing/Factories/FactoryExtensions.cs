using System;
using System.Collections.Generic;
using System.Linq;
using AndcultureCode.CSharp.Testing.Exceptions;

namespace AndcultureCode.CSharp.Testing.Factories
{
    public static class FactoryExtensions
    {
        #region Private Members

        private static readonly string                              NAME_DELIMITER = "-";
        private static readonly IDictionary<string, FactoryBuilder> namedBuilders  = new Dictionary<string, FactoryBuilder>();

        #endregion Private Members


        #region Public Methods

        #region Build

        public static T Build<T>()                                              => BuildObject<T>(new List<Action<T>>(), typeof(T).Name);
        public static T Build<T>(params Action<T>[] properties)                 => BuildObject<T>(properties.ToList(), typeof(T).Name);
        public static T Build<T>(string name)                                   => BuildObject<T>(new List<Action<T>>(), name);
        public static T Build<T>(List<string> names)                            => BuildObject<T>(new List<Action<T>>(), names);
        public static T Build<T>(Action<T> property)                            => BuildObject   (new List<Action<T>> { property }, typeof(T).Name);
        public static T Build<T>(string name, Action<T> property)               => BuildObject   (new List<Action<T>> { property }, name);
        public static T Build<T>(List<Action<T>> properties)                    => BuildObject   (properties, typeof(T).Name);
        public static T Build<T>(string name, List<Action<T>> properties)       => BuildObject   (properties, name);
        public static T Build<T>(string name, params Action<T>[] properties)    => BuildObject   (properties.ToList(), name);

        #endregion Build


        #region Define

        public static void DefineFactory<T>(this Factory factory, string name, Func<T> builder)
        {
            var keyname = GetKeyName<T>(name);
            Define<T>(factory, builder, keyname);
        }

        public static void DefineFactory<T>(this Factory factory, List<string> names, Func<List<string>,T> builder)
        {
            var keyname = GetKeyName<T>(string.Join(NAME_DELIMITER, names.OrderBy(e => e)));
            Define<T>(factory, builder, names);
        }

        public static void DefineFactory<T>(this Factory factory, Func<T> builder)
        {
            var keyname = GetKeyName<T>(typeof(T).Name);
            Define<T>(factory, builder, keyname);
        }

        public static IEnumerable<string> DefinedFactories => namedBuilders.Select(x => x.Key);

        #endregion Define


        #region Get

        public static string GetKeyName<T>(string name) => GetKeyForType<T>() + "_" + name;

        #endregion Get


        #region Reset

        public static void ClearFactoryDefinitions() => namedBuilders.Clear();

        #endregion Reset

        #endregion Public Methods


        #region Private Methods

        private static T BuildObject<T>(List<Action<T>> properties, string name)
        {
            var keyName = GetKeyName<T>(name);
            if (!namedBuilders.ContainsKey(keyName))
            {
                throw new MissingFactoryException(name + " is not yet registered as a factory (Tests\\Testing\\Factories).  You can only build objects for factories that have been created");
            }
            var builder = namedBuilders[keyName];
            var result  = (T)builder.BuildCallback();

            properties.ForEach(p => p(result));

            return result;
        }

        private static T BuildObject<T>(List<Action<T>> properties, List<string> names)
        {
            var sortedKeyName = string.Join(NAME_DELIMITER, names.OrderBy(e => e));
            return BuildObject(properties, sortedKeyName);
        }

        private static void Define<T>(Factory factory, Func<T> buildCallback, string key)
        {
            if (namedBuilders.ContainsKey(key))
            {
                OutputWarning($"{key} is already registered. You can only register one factory per type/name.");
                return;
            }

            namedBuilders[key] = new FactoryBuilder
            {
                Factory       = factory,
                BuildCallback = () => buildCallback()
            };
        }

        private static void Define<T>(Factory factory, Func<List<string>, T> buildCallback, List<string> names)
        {
            var key = string.Join(NAME_DELIMITER, names.OrderBy(e => e));
            if (namedBuilders.ContainsKey(key))
            {
                OutputWarning($"{key} is already registered. You can only register one factory per type/name.");
                return;
            }

            namedBuilders[key] = new FactoryBuilder
            {
                Factory       = factory,
                BuildCallback = () => buildCallback(names)
            };
        }

        private static string GetKeyForType<T>() => typeof(T).FullName;

        private static void OutputWarning(string message)
        {
            if (!FactorySettings.Instance.Debug)
            {
                return;
            }

            Console.WriteLine($"WARNING: [Factories] {message}");
        }

        #endregion Private Methods

    }
}