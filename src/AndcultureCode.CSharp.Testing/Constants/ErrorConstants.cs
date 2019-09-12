using AndcultureCode.CSharp.Core.Models;

namespace AndcultureCode.CSharp.Testing.Constants
{
    public class ErrorConstants
    {
        public const string BASIC_ERROR_KEY      = "TESTERRORKEY";
        public const string BASIC_ERROR_MESSAGE  = "TEST ERROR MESSAGE";
        public const string JOB_CANCELED_MESSAGE = "The operation was canceled.";

        public static Error BasicError => new Error { Key = BASIC_ERROR_KEY, Message = BASIC_ERROR_MESSAGE };
    }
}