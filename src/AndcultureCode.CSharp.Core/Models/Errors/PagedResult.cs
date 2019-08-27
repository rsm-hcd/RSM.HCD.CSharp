using System.Collections.Generic;
using System.Linq;
using AndcultureCode.CSharp.Core.Interfaces;

namespace AndcultureCode.CSharp.Core.Models.Errors
{
    public class PagedResult<T> : IResult<T>
    {
        #region Properties

        public int                        ErrorCount     => Errors != null ? Errors.Count : 0;
        public List<IError>               Errors         { get; set; }
        public bool                       HasErrors      => Errors != null && Errors.Any();
        public Dictionary<string, string> NextLinkParams { get; set; }
        public T                          ResultObject   { get; set; }
        public long                       RowCount       { get; set; }

        #endregion Properties


        #region Constructors

        public PagedResult(T rows, long rowCount) : this(rows, rowCount, null) {}
        public PagedResult(T rows, long rowCount, Dictionary<string, string> nextLinkParams)
        {
            NextLinkParams = nextLinkParams;
            ResultObject   = rows;
            RowCount       = rowCount;
        }

        #endregion Constructors
    }
}
