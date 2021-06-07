using System.Net.Http;
using AndcultureCode.CSharp.Testing.Models.Stubs;
using AndcultureCode.CSharp.Testing.Tests;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace AndcultureCode.CSharp.Extensions.Tests
{
    public class HttpResponseMessageExtensionsTest : BaseUnitTest
    {
        #region Setup

        public HttpResponseMessageExtensionsTest(ITestOutputHelper output) : base(output)
        {
        }

        #endregion Setup

        #region FromJson

        [Fact]
        public void FromJson_When_Model_Deserialized_Then_Returns_Model_Of_Matching_Type()
        {
            // Arrange
            var response = new HttpResponseMessage();
            var entity = Build<UserStub>(
                (e) => e.FirstName = "andculture",
                (e) => e.LastName = "engineering",
                (e) => e.EmailAddress = "developer@andculture.com"
            );

            var jsonEntity = Newtonsoft.Json.JsonConvert.SerializeObject(entity);
            response.Content = new StringContent(jsonEntity);

            // Act
            var result = response.FromJson<UserStub>();

            // Assert
            result.ShouldBeOfType(typeof(UserStub));
            result.FirstName.ShouldBe(entity.FirstName);
            result.LastName.ShouldBe(entity.LastName);
            result.EmailAddress.ShouldBe(entity.EmailAddress);
        }
        [Fact]
        public void FromJson_When_Content_Is_Not_Object_Then_Returns_Parsing_Error()
        {
            // Arrange
            var response = new HttpResponseMessage();
            response.Content = new StringContent("Hello-World");

            // Act & Assert
            Should.Throw<Newtonsoft.Json.JsonReaderException>(() => response.FromJson<UserStub>());
        }

        #endregion FromJson
    }
}
