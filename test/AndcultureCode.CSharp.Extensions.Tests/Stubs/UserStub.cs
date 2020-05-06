namespace AndcultureCode.CSharp.Extensions.Tests.Stubs
{
    public class UserStub
    {
        #region Public Properties

        public long   Id                  { get; set; }
        public string EmailAddress        { get; set; }
        public string Name                { get; set; }
        public long?  RelatedUserStubId   { get; set; }

        #endregion Public Properties

        #region Navigation Properties

        public UserStub RelatedUserStub { get; set; }

        #endregion Navigation Properties
    }
}