using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Shouldly;
using Xunit;

namespace AndcultureCode.CSharp.Extensions.Tests
{
    public class AssemblyExtensionsTest
    {
        #region NullAssembly

        [Fact]
        public void GetSafetlyTypes_Given_Empty_Type_With_Null_Assembly()
        {
            Assembly assembly = null;
            var types = assembly.GetSafetlyTypes(); // act
            types.ShouldBeEmpty();                  // Assert
        }

        #endregion NullAssembly 

        #region NotNullAssembly

        [Fact]
        public void GetSafetlyTypes_Given_Types_With_Not_Null_Assembly()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetSafetlyTypes(); // act
            types.ShouldNotBeEmpty();               // Assert
        }

        [Fact]
        public void GetSafetlyTypes_Given_Types_With_Domain_Assemblies()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            List<Type> types = assemblies.SelectMany(o => o.GetSafetlyTypes()).ToList();    // act
            types.ShouldNotBeEmpty();                                                       // Assert
        }

        #endregion NotNullAssembly

        #region exception failures

        internal class AssemblyFailure_ReflectionTypeLoadException : Assembly
        {
            public override Type[] GetTypes()
            {
                throw new ReflectionTypeLoadException(
                    classes: new List<Type> { this.GetType() }.ToArray(),
                    exceptions: new List<Exception> { new Exception() }.ToArray()
                );
            }
        }

        internal class AssemblyFailure_Exception : Assembly
        {
            public override Type[] GetTypes()
            {
                throw new Exception();
            }
        }

        [Fact]
        public void GetSafetlyTypes_Given_Types_From_ReflectionTypeLoadException()
        {
            var assembly = new AssemblyFailure_ReflectionTypeLoadException();
            var types = assembly.GetSafetlyTypes();    // act
            types.ShouldNotBeEmpty();                  // Assert
        }

        [Fact]
        public void GetSafetlyTypes_Given_Types_From_Exception()
        {
            var assembly = new AssemblyFailure_Exception();
            var types = assembly.GetSafetlyTypes();    // act
            types.ShouldBeEmpty();                     // Assert
        }

        #endregion

    }

}