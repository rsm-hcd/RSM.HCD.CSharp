using RSM.HCD.CSharp.Core.Enumerations;
using RSM.HCD.CSharp.Core.Interfaces;

namespace RSM.HCD.CSharp.Core.Models.Errors
{
    /// <summary>
    /// TODO https://github.com/rsm-hcd/RSM.HCD.CSharp.Core/issues/38
    /// </summary>
    public class Error : IError
    {
        /// <summary>
        /// TODO https://github.com/rsm-hcd/RSM.HCD.CSharp.Core/issues/38
        /// </summary>
        public ErrorType ErrorType { get; set; }

        /// <summary>
        /// TODO https://github.com/rsm-hcd/RSM.HCD.CSharp.Core/issues/38
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// TODO https://github.com/rsm-hcd/RSM.HCD.CSharp.Core/issues/38
        /// </summary>
        public string Message { get; set; }
    }
}
