namespace AndcultureCode.CSharp.Extensions.Tests.Stubs
{
    public class TestEntity
    {
        #region Public Properties

        public long   Id                  { get; set; }
        public string EmailAddress        { get; set; }
        public string Name                { get; set; }
        public long?  RelatedTestEntityId { get; set; }

        #endregion Public Properties

        #region Navigation Properties

        public TestEntity RelatedTestEntity { get; set; }

        #endregion Navigation Properties
    }
}