using System.Net.Http;
using AndcultureCode.CSharp.Extensions.Tests.Stubs;
using Shouldly;
using Xunit;
namespace AndcultureCode.CSharp.Extensions.Tests
{
    public class HttpResponseMessageExtensionsTest
    {
        [Fact]
        public void FromJson_When_Model_Deserialized_Then_Returns_Model_Of_Matching_Type()
        {
            // Arrange
            var response = new HttpResponseMessage();
            var entity = new UserStub
            {
                Name = "andculture engineering",
                EmailAddress = "developer@andculture.com"
            };

            var jsonEntity = Newtonsoft.Json.JsonConvert.SerializeObject(entity);
            response.Content = new StringContent(jsonEntity);

            // Act
            var result = response.FromJson<UserStub>();

            // Assert
            result.ShouldBeOfType(typeof(UserStub));
            result.Name.ShouldBe(entity.Name);
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


    }
}