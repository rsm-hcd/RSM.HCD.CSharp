using RSM.HCD.CSharp.Core.Interfaces;
using RSM.HCD.CSharp.Core.Interfaces.Entity;
using RSM.HCD.CSharp.Core.Models.Errors;

namespace RSM.HCD.CSharp.Testing.Constants
{
    /// <summary>
    /// Holds common error keys, messages, Error object configurations, etc.
    /// </summary>
    public class ErrorConstants
    {
        /// <summary>
        /// Generic error key for testing
        /// </summary>
        public const string BASIC_ERROR_KEY = "TESTERRORKEY";

        /// <summary>
        /// Generic error message for testing
        /// </summary>
        public const string BASIC_ERROR_MESSAGE = "TEST ERROR MESSAGE";

        /// <summary>
        /// Detailed output message to display when expecting errors on a result that has a null `Errors` property
        /// </summary>
        public static string ERROR_ERRORS_LIST_IS_NULL_MESSAGE = $"Expected {typeof(IResult<>).Name} to have errors, but instead Errors is 'null'";

        /// <summary>
        /// Friendlier output message to display when expected entity is not valid for test assertion to continue
        /// </summary>
        public static string ERROR_EXPECTED_ENTITY_IS_NULL_MESSAGE = $"Expected {nameof(IEntity)} should have a value, but instead is 'null'. Verify your test arrangement is correct.";

        public const string JOB_CANCELED_MESSAGE = "The operation was canceled.";

        /// <summary>
        /// Generic Error object for testing
        /// </summary>
        public static Error BasicError => new Error { Key = BASIC_ERROR_KEY, Message = BASIC_ERROR_MESSAGE };
    }
}
