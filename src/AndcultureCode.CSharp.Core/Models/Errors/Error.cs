using AndcultureCode.CSharp.Core.Enumerations;
using AndcultureCode.CSharp.Core.Interfaces;

namespace AndcultureCode.CSharp.Core.Models
{
    public class Error : IError
    {
        public ErrorType ErrorType { get; set; }
        public string    Key       { get; set; }
        public string    Message   { get; set; }
    }
}
