using RSM.HCD.CSharp.Core.Enumerations;

namespace RSM.HCD.CSharp.Core.Interfaces
{
    public interface IError
    {
        ErrorType ErrorType { get; set; }
        string Key { get; set; }
        string Message { get; set; }
    }
}
