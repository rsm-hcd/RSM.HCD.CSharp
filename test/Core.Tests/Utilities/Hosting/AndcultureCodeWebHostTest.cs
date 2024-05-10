using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using RSM.HCD.CSharp.Testing;
using RSM.HCD.CSharp.Testing.Extensions;
using RSM.HCD.CSharp.Core.Models;
using RSM.HCD.CSharp.Core.Extensions;
using RSM.HCD.CSharp.Core.Interfaces;
using RSM.HCD.CSharp.Core.Enumerations;
using RSM.HCD.CSharp.Core.Utilities.Hosting;
using RSM.HCD.CSharp.Testing.Tests;

namespace RSM.HCD.CSharp.Core.Tests.Unit.Utilities.Configuration
{
    public class RSMWebHostTest : CoreUnitTest
    {
        #region Setup

        public RSMWebHostTest(ITestOutputHelper output) : base(output) { }

        #endregion Setup


        #region Preload

        [Fact]
        public void Preload_When_Args_Null_Returns_Builder()
        {
            RSMWebHost.Preload(args: null).ShouldNotBeNull();
        }

        [Fact]
        public void Preload_When_Args_Empty_Array_Returns_Builder()
        {
            RSMWebHost.Preload(args: new string[] { }).ShouldNotBeNull();
        }

        [Fact]
        public void Preload_When_Args_Array_Returns_Builder()
        {
            RSMWebHost.Preload(args: new string[] { Random.String() }).ShouldNotBeNull();
        }

        #endregion Preload
    }
}
