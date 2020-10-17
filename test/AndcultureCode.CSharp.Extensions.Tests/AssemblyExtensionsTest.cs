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

        #endregion NotNullAssembly

    }

}