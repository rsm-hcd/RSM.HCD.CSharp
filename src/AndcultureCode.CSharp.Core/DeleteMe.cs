using AndcultureCode.CSharp.Core.Extensions;
using AndcultureCode.CSharp.Core.Interfaces;

namespace AndcultureCode.CSharp.Core
{
    /// <summary>
    /// TODO: Documentation example scenarios
    /// #1 - shared data across chained methods
    /// #2 - arugments vs no-arguments
    /// #3 - general formatting
    /// #4 - skipping if errors when chaining
    /// #5 - take large real-world class/method an show iterations of refactoring
    /// </summary>
    public class DeleteMe
    {
        #region Public Methods

        public IResult<bool> DoWork(string name) => Do<bool>
            .Try(ValidateWithoutArguments)
            .Then((r) => ValidateWithArguments(r, name))
            .Then((r) =>
        {



            return true;
        })
        .Result;

        #endregion Public Methods

        #region Private Methods



        private bool ValidateWithArguments(IResult<bool> r, string name)
        {
            r.AddError("ValidateWithArguments", "error");
            return true;
        }

        private bool ValidateWithoutArguments(IResult<bool> r)
        {
            r.AddError("ValidateWithoutArguments", "error");
            return true;
        }

        #endregion Private Methods
    }
}
