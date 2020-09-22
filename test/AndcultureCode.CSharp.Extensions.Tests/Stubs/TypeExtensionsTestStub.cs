namespace AndcultureCode.CSharp.Extensions.Tests.Stubs
{
    public class TypeExtensionsTestStub
    {
        public const string TEST_CONST_STRING = "TEST_CONST_STRING";
        private string TEST_PRIVATE_STRING_PROPERTY { get; set; }
        public static string TEST_STATIC_STRING = "TEST_STATIC_STRING";
        public string TEST_STRING_PROPERTY { get; set; }

        public TypeExtensionsTestStub()
        {
            // set value to a test value
            TEST_STRING_PROPERTY = nameof(TEST_STRING_PROPERTY);
        }
    }
}
