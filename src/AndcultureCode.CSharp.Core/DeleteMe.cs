using AndcultureCode.CSharp.Core.Extensions;
using AndcultureCode.CSharp.Core.Interfaces;

namespace AndcultureCode.CSharp.Core
{
    public class DeleteMe
    {
        #region Public Methods

        public IResult<bool> DoWork(string name) => Do<bool>
            .Try(ValidateWithoutArguments)
            .Next((r) => ValidateWithArguments(r, name))
            .Next((r) =>
        {

            return false;
        }).Result;

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
