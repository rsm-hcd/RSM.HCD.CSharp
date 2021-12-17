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
        #region Setup

        internal class AssemblyFailure_ReflectionTypeLoadException : Assembly
        {
            public override Type[] GetTypes()
            {
                throw new ReflectionTypeLoadException(
                    classes: new Type[] { this.GetType() },
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

        #endregion Setup

        #region GetLoadableTypes

        [Fact]
        public void GetLoadableTypes_When_Assembly_Null_Returns_Empty_List()
        {
            // Arrange
            Assembly assembly = null;

            // Act
            var types = assembly.GetLoadableTypes();

            // Assert
            types.ShouldBeEmpty();
        }

        [Fact]
        public void GetLoadableTypes_When_Assembly_Valid_Returns_List_With_Values()
        {
            // Arrange
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Act
            var types = assembly.GetLoadableTypes();

            // Assert
            types.ShouldNotBeEmpty();
        }

        [Fact]
        public void GetLoadableTypes_Returns_Not_Empty_Type_List_With_Domain_Assemblies()
        {
            // Arrange
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            // Act
            List<Type> types = assemblies.SelectMany(o => o.GetLoadableTypes()).ToList();

            // Assert
            types.ShouldNotBeEmpty();
        }

        [Fact]
        public void GetLoadableTypes_When_ReflectionTypeLoadException_Thrown_Returns_Successfully_Loaded_Types()
        {
            // Arrange
            var assembly = new AssemblyFailure_ReflectionTypeLoadException();

            // Act
            var types = assembly.GetLoadableTypes();

            // Assert
            types.ShouldNotBeEmpty();
        }

        [Fact]
        public void GetLoadableTypes_When_Assembly_Throws_Returns_Empty_List()
        {
            // Arrange
            var assembly = new AssemblyFailure_Exception();

            // Act
            var types = assembly.GetLoadableTypes();

            // Assert
            types.ShouldBeEmpty();
        }

        #endregion GetLoadableTypes
    }
}
