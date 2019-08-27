using AndcultureCode.CSharp.Core.Enumerations;

namespace AndcultureCode.CSharp.Core.Interfaces
{
    public interface IError
    {
        ErrorType ErrorType { get; set; }
        string    Key       { get; set; }
        string    Message   { get; set; }
    }
}
