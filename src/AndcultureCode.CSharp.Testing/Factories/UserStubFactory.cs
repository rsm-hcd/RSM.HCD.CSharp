using AndcultureCode.CSharp.Testing.Models.Stubs;

namespace AndcultureCode.CSharp.Testing.Factories
{
    /// <summary>
    /// Factory for building out configurations of the `UserStub` class
    /// </summary>
    public class UserStubFactory : Factory
    {
        #region Constants

        /// <summary>
        /// Returns a user stub with a gmail address
        /// </summary>
        public const string WITH_GMAIL_EMAIL = "WITH_GMAIL_EMAIL";

        /// <summary>
        /// Returns a user stub with a yahoo address
        /// </summary>
        public const string WITH_YAHOO_EMAIL = "WITH_YAHOO_EMAIL";

        #endregion Constants

        #region Public Methods

        /// <inheritdoc />
        public override void Define()
        {
            this.DefineFactory(BuildDefaultUserStub);

            this.DefineFactory(WITH_GMAIL_EMAIL, () =>
            {
                var userStub = BuildDefaultUserStub();
                userStub.EmailAddress = $"{userStub.FirstName}{userStub.LastName}@gmail.com";
                return userStub;
            });

            this.DefineFactory(WITH_YAHOO_EMAIL, () =>
            {
                var userStub = BuildDefaultUserStub();
                userStub.EmailAddress = $"{userStub.FirstName}{userStub.LastName}@yahoo.com";
                return userStub;
            });
        }

        #endregion Public Methods

        #region Private Methods

        private UserStub BuildDefaultUserStub() => new UserStub
        {
            EmailAddress = Faker.Internet.Email(),
            FirstName = Faker.Name.FirstName(),
            LastName = Faker.Name.LastName(),
        };

        #endregion Private Methods
    }
}
