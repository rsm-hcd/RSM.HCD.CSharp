using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Moq;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace RSM.HCD.CSharp.Extensions.Tests.Unit.Extensions
{
    public class IConfigurationRootExtensionsTest : BaseExtensionsTest
    {
        #region Setup

        public IConfigurationRootExtensionsTest(ITestOutputHelper output) : base(output) { }

        #endregion Setup

        #region GetDatabaseConnectionString

        [Fact]
        public void GetDatabaseConnectionString_When_Configuration_Null_Returns_Null()
        {
            IConfigurationRootExtensions.GetDatabaseConnectionString(null).ShouldBeNull();
        }

        [Fact]
        public void GetDatabaseConnectionString_When_ConnectionStrings_Section_NotFound_Returns_Null()
        {
            // Arrange
            var configurationMock = new Mock<IConfigurationRoot>();

            // Act & Assert
            configurationMock.Object.GetDatabaseConnectionString().ShouldBeNull();
        }

        [Fact]
        public void GetDatabaseConnectionString_When_ConnectionStrings_Section_Missing_PrimaryDatabase_Returns_Null()
        {
            // Arrange
            var configurationMock = new Mock<IConfigurationRoot>();
            configurationMock
                .SetupGet(e => e["ConnectionStrings:Other"]).Returns("unexpected");

            // Act & Assert
            configurationMock.Object.GetDatabaseConnectionString().ShouldBeNull();
        }

        [Fact]
        public void GetDatabaseConnectionString_When_ConnectionStrings_Section_Contains_PrimaryDatabase_Returns_Value()
        {
            // Arrange
            var expected = Random.String();

            var apiConfigurationSectionMock = new Mock<IConfigurationSection>();
            apiConfigurationSectionMock
                .SetupGet(e => e.Value)
                .Returns(expected);

            var connectionsConfigurationSectionMock = new Mock<IConfigurationSection>();
            connectionsConfigurationSectionMock
                .Setup(e => e.GetSection(IConfigurationRootExtensions.DEFAULT_DATABASE_KEY))
                .Returns(apiConfigurationSectionMock.Object);

            var configurationMock = new Mock<IConfigurationRoot>();
            configurationMock
                .Setup(e => e.GetSection("ConnectionStrings"))
                .Returns(connectionsConfigurationSectionMock.Object);

            // Act
            var result = configurationMock.Object.GetDatabaseConnectionString();

            // Assert
            result.ShouldBe(expected);
        }

        #endregion GetDatabaseConnectionString

        #region GetDatabaseName

        [Fact]
        public void GetDatabaseName_When_Configuration_Null_Returns_Null()
        {
            IConfigurationRootExtensions.GetDatabaseName(null).ShouldBeNull();
        }

        [Fact]
        public void GetDatabaseName_When_ConnectionStrings_Section_NotFound_Returns_Null()
        {
            // Arrange
            var configurationMock = new Mock<IConfigurationRoot>();

            // Act & Assert
            configurationMock.Object.GetDatabaseName().ShouldBeNull();
        }

        [Fact]
        public void GetDatabaseName_When_ConnectionStrings_Section_Missing_PrimaryDatabase_Returns_Null()
        {
            // Arrange
            var configurationMock = new Mock<IConfigurationRoot>();
            configurationMock
                .SetupGet(e => e["ConnectionStrings:Other"]).Returns("unexpected");

            // Act & Assert
            configurationMock.Object.GetDatabaseName().ShouldBeNull();
        }

        [Fact]
        public void GetDatabaseName_When_ConnectionStrings_Section_Contains_PrimaryDatabase_Missing_Database_Property_Returns_Null()
        {
            // Arrange
            var valueWithoutProperty = "Prop1=Value1;Proper2=Value2";

            var apiConfigurationSectionMock = new Mock<IConfigurationSection>();
            apiConfigurationSectionMock
                .SetupGet(e => e.Value)
                .Returns(valueWithoutProperty);

            var connectionsConfigurationSectionMock = new Mock<IConfigurationSection>();
            connectionsConfigurationSectionMock
                .Setup(e => e.GetSection(IConfigurationRootExtensions.DEFAULT_DATABASE_KEY))
                .Returns(apiConfigurationSectionMock.Object);

            var configurationMock = new Mock<IConfigurationRoot>();
            configurationMock
                .Setup(e => e.GetSection("ConnectionStrings"))
                .Returns(connectionsConfigurationSectionMock.Object);

            // Act
            var result = configurationMock.Object.GetDatabaseName();

            // Assert
            result.ShouldBeNull();
        }

        [Theory]
        [InlineData("database")]
        [InlineData("Database")]
        [InlineData("DataBAse")]
        [InlineData(" DataBAse")]
        public void GetDatabaseName_When_ConnectionStrings_Section_Contains_PrimaryDatabase_Contains_Database_Property_Returns_Value(string databaseKey)
        {
            // Arrange
            var expected = "databaseValue";
            var valueWithoutProperty = $"Prop1=Value1;{databaseKey}={expected}";

            var apiConfigurationSectionMock = new Mock<IConfigurationSection>();
            apiConfigurationSectionMock
                .SetupGet(e => e.Value)
                .Returns(valueWithoutProperty);

            var connectionsConfigurationSectionMock = new Mock<IConfigurationSection>();
            connectionsConfigurationSectionMock
                .Setup(e => e.GetSection(IConfigurationRootExtensions.DEFAULT_DATABASE_KEY))
                .Returns(apiConfigurationSectionMock.Object);

            var configurationMock = new Mock<IConfigurationRoot>();
            configurationMock
                .Setup(e => e.GetSection("ConnectionStrings"))
                .Returns(connectionsConfigurationSectionMock.Object);

            // Act
            var result = configurationMock.Object.GetDatabaseName();

            // Assert
            result.ShouldBe(expected);
        }

        [Theory]
        [InlineData("initial catalog")]
        [InlineData("Initial Catalog")]
        [InlineData("INitial CAtalOG")]
        [InlineData(" Initial CATaLOG")]
        public void GetDatabaseName_When_ConnectionStrings_Section_Contains_PrimaryDatabase_Contains_InitialCatalog_Property_Returns_Value(string databaseKey)
        {
            // Arrange
            var expected = "databaseValue";
            var valueWithoutProperty = $"Prop1=Value1;{databaseKey}={expected}";

            var apiConfigurationSectionMock = new Mock<IConfigurationSection>();
            apiConfigurationSectionMock
                .SetupGet(e => e.Value)
                .Returns(valueWithoutProperty);

            var connectionsConfigurationSectionMock = new Mock<IConfigurationSection>();
            connectionsConfigurationSectionMock
                .Setup(e => e.GetSection(IConfigurationRootExtensions.DEFAULT_DATABASE_KEY))
                .Returns(apiConfigurationSectionMock.Object);

            var configurationMock = new Mock<IConfigurationRoot>();
            configurationMock
                .Setup(e => e.GetSection("ConnectionStrings"))
                .Returns(connectionsConfigurationSectionMock.Object);

            // Act
            var result = configurationMock.Object.GetDatabaseName();

            // Assert
            result.ShouldBe(expected);
        }

        #endregion GetDatabaseName

        #region GetVersion

        [Fact]
        public void GetVersion_Given_Configuration_IsNull_Returns_Null()
        {
            IConfigurationRootExtensions.GetVersion(null).ShouldBeNull();
        }

        [Fact]
        public void GetVersion_Given_Configuration_IsEmpty_Returns_Null()
        {
            new ConfigurationBuilder().Build().GetVersion().ShouldBeNull();
        }

        [Fact]
        public void GetVersion_When_Version_IsNotTemplate_Returns_VersionValue()
        {
            // Arrange
            var expected = Random.String();
            var configuration = new Dictionary<string, string>
            {
                { IConfigurationRootExtensions.CONFIGURATION_VERSION_KEY, expected }
            };
            var sut = new ConfigurationBuilder().AddInMemoryCollection(configuration).Build();

            // Act
            var result = sut.GetVersion();

            // Assert
            result.ShouldBe(expected);
        }

        [Fact]
        public void GetVersion_When_Version_IsTemplate_When_IsDevelopment_False_Returns_VersionValue()
        {
            // Arrange
            var staticPortion = Random.String();
            var versionTemplate = $"{staticPortion}.{IConfigurationRootExtensions.CONFIGURATION_VERSION_TEMPLATE}";
            var expected = versionTemplate;
            var configuration = new Dictionary<string, string>
            {
                { IConfigurationRootExtensions.CONFIGURATION_VERSION_KEY, versionTemplate }
            };
            var sut = new ConfigurationBuilder().AddInMemoryCollection(configuration).Build();

            // Act
            var result = sut.GetVersion(isDevelopment: false);

            // Assert
            result.ShouldContain(staticPortion);
            result.ShouldContain(IConfigurationRootExtensions.CONFIGURATION_VERSION_TEMPLATE);
        }

        [Fact]
        public void GetVersion_When_Version_IsTemplate_When_IsDevelopment_True_Returns_VersionValue_With_DevelopmentToken()
        {
            // Arrange
            var staticPortion = Random.String();
            var versionTemplate = $"{staticPortion}.{IConfigurationRootExtensions.CONFIGURATION_VERSION_TEMPLATE}";
            var expected = $"{staticPortion}.{IConfigurationRootExtensions.CONFIGURATION_VERSION_DEVELOPMENT_VALUE}";
            var configuration = new Dictionary<string, string>
            {
                { IConfigurationRootExtensions.CONFIGURATION_VERSION_KEY, versionTemplate }
            };
            var sut = new ConfigurationBuilder().AddInMemoryCollection(configuration).Build();

            // Act
            var result = sut.GetVersion(isDevelopment: true);

            // Assert
            result.ShouldContain(expected);
        }

        #endregion GetVersion
    }
}
