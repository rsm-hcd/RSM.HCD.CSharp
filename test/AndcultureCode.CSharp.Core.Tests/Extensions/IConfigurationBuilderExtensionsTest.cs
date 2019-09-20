using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using AndcultureCode.CSharp.Testing;
using AndcultureCode.CSharp.Testing.Extensions;
using AndcultureCode.CSharp.Core.Models;
using AndcultureCode.CSharp.Core.Extensions;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Enumerations;

namespace AndcultureCode.CSharp.Core.Tests.Unit.Extensions
{
    public class IConfigurationBuilderExtensionsTest : UnitTestBase
    {
        #region Setup

        public IConfigurationBuilderExtensionsTest(ITestOutputHelper output) : base(output) {}

        #endregion Setup


        #region AddAmazonElasticBeanstalk

        [Fact(Skip = "TODO: NFPA-84")]
        public void AddAmazonElasticBeanstalk_Write_Tests()
        {
            true.ShouldBeFalse();
        }

        #endregion AddAmazonElasticBeanstalk
    }
}