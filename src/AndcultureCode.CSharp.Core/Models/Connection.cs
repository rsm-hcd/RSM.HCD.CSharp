using AndcultureCode.CSharp.Core.Interfaces.Data;
using AndcultureCode.CSharp.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace AndcultureCode.CSharp.Core.Models
{
    /// <summary>
    /// Breaks out standard connection string params into easy to consume object
    /// </summary>
    public class Connection : IConnection
    {
        #region Properties

        /// <summary>
        /// Additional configuration details
        /// </summary>
        public string AdditionalParameters { get; set; }

        /// <summary>
        /// Database name
        /// </summary>
        public string Database { get; set; }

        /// <summary>
        /// Data host
        /// </summary>
        public string Datasource { get; set; }

        /// <summary>
        /// Hopefully a secure password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// User identifier for the connectiong
        /// </summary>
        public string UserId { get; set; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Return the data to the form from which it came, a semi-colon delimited connection string
        /// </summary>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public virtual string ToString(string delimiter = ";")
        {
            var results = new List<string>
            {
                Datasource,
                Database,
                Password,
                UserId,
                AdditionalParameters
            };

            return results.Where(ValidParameter).Join(delimiter);
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Determines if the supplied value is a valid param
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected bool ValidParameter(string value) => !string.IsNullOrEmpty(value);

        #endregion Protected Methods
    }
}
