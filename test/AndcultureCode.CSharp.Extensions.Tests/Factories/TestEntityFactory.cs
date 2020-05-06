using AndcultureCode.CSharp.Extensions.Tests.Stubs;
using AndcultureCode.CSharp.Testing.Factories;
using Bogus;

namespace AndcultureCode.CSharp.Extensions.Tests.Factories
{
    public class TestEntityFactory : Factory
    {
        #region Constants

        public const string WITH_GMAIL_EMAIL = "WITH_GMAIL_EMAIL";
        public const string WITH_YAHOO_EMAIL = "WITH_YAHOO_EMAIL";

        #endregion Constants

        public override void Define()
        {
            var faker = new Faker();
            var name = faker.Person.FullName;
            var emailAddress = faker.Person.Email;

            this.DefineFactory(() => new UserStub
            {
                Name = name,
                EmailAddress = emailAddress,
            });

            this.DefineFactory(WITH_GMAIL_EMAIL, () => new UserStub
            {
                Name = name,
                EmailAddress = $"{name}@gmail.com",
            });

            this.DefineFactory(WITH_YAHOO_EMAIL, () => new UserStub
            {
                Name = name,
                EmailAddress = $"{name}@yahoo.com",
            });
        }
    }
}
