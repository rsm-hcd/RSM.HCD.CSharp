using AndcultureCode.CSharp.Extensions.Tests.Stubs;
using AndcultureCode.CSharp.Testing.Factories;
using Bogus;

namespace AndcultureCode.CSharp.Extensions.Tests.Factories
{
    public class UserStubFactory : Factory
    {
        #region Constants

        public const string WITH_GMAIL_EMAIL = "WITH_GMAIL_EMAIL";
        public const string WITH_YAHOO_EMAIL = "WITH_YAHOO_EMAIL";

        #endregion Constants

        #region Public Methods

        public override void Define()
        {
            this.DefineFactory(() => BuildDefaultUserStub());

            this.DefineFactory(WITH_GMAIL_EMAIL, () =>
            {
                var userStub          = BuildDefaultUserStub();
                userStub.EmailAddress = $"{userStub.Name}@gmail.com";
                return userStub;
            });

            this.DefineFactory(WITH_YAHOO_EMAIL, () =>
            {
                var userStub          = BuildDefaultUserStub();
                userStub.EmailAddress = $"{userStub.Name}@yahoo.com";
                return userStub;
            });
        }

        #endregion Public Methods

        #region Private Methods

        private UserStub BuildDefaultUserStub()
        {
            var faker        = new Faker();
            var name         = faker.Person.FullName;
            var emailAddress = faker.Person.Email;
            return new UserStub
            {
                Name         = name,
                EmailAddress = emailAddress,
            };
        }

        #endregion Private Methods
    }
}
