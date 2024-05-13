using RSM.HCD.CSharp.Core;
using RSM.HCD.CSharp.Core.Extensions;
using RSM.HCD.CSharp.Core.Interfaces;
using System.Collections.Generic;

namespace RSM.HCD.CSharp.Core.Models.Mail
{
    /// <summary>
    /// Commonly used email settings
    /// </summary>
    public class EmailSettings
    {
        #region Constants

        /// <summary>
        /// Required property is not supplied
        /// </summary>
        public const string ERROR_MISSING_PROPERTY = "ERROR_MISSING_PROPERTY";

        #endregion Constants

        #region Public Properties

        /// <summary>
        /// Comma-separated list of custom X-Headers
        /// </summary>
        /// <value>Example: 'X-MyHeader: MyValue'</value>
        public string CustomHeaders { get; set; }

        /// <summary>
        /// Should a test email be used?
        /// </summary>
        /// <value></value>
        public bool SendTestEmail { get; set; }

        /// <summary>
        /// Transforms 'CustomHeaders' into a dictionary
        /// </summary>
        public Dictionary<string, string> CustomHeadersAsDictionary
        {
            get
            {
                if (string.IsNullOrWhiteSpace(CustomHeaders) || !CustomHeaders.Contains(":"))
                {
                    return null;
                }

                var headers = new Dictionary<string, string>();

                foreach (var pair in CustomHeaders.Split(','))
                {
                    var pairParts = pair.Split(':');
                    var key = pairParts[0].Trim();
                    var value = pairParts[1].Trim();
                    headers.Add(key, value);
                }

                return headers;
            }
        }

        /// <summary>
        /// This email address is for global use of background jobs and other processes
        /// that warrant developer attention if it fails or succeeds
        /// </summary>
        /// <value></value>
        public string DeveloperEmailAddress { get; set; }

        /// <summary>
        ///  This email address is used for automated testing
        /// </summary>
        /// <value></value>
        public string TestEmailAddress { get; set; }

        /// <summary>
        /// Test email's environment token
        /// </summary>
        /// <value></value>
        public string TestEmailEnvironmentToken { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Returns developer account email address for specified environment
        /// </summary>
        /// <param name="environmentName"></param>
        /// <returns></returns>
        public string GetDeveloperEmailAddress(string environmentName)
            => DeveloperEmailAddress?.Replace("{env}", environmentName);

        /// <summary>
        /// Handles determining if we are sending a test e-mail or not, and creates a list containing the appropriate address.
        /// </summary>
        /// <param name="email">The intended recipient e-mail</param>
        /// <param name="environmentName"></param>
        /// <param name="isProduction"></param>
        /// <returns>Returns a list containing the appropriate address. Returns an empty list if we're not on production and environment variables don't indicate to send a test e-mail.</returns>
        public IResult<List<string>> GetRecipientEmailOrTest(string email, string environmentName, bool isProduction) => Do<List<string>>.Try((r) =>
        {
            var toEmails = new List<string>();

            if (!SendTestEmail && !isProduction)
            {
                return toEmails;
            }

            if (isProduction)
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    r.AddError(ERROR_MISSING_PROPERTY, $"Recipient email was empty.");
                    return toEmails;
                }

                toEmails.Add(email);

                return toEmails;
            }

            // Try to get the test e-mail address, return if we fail.
            var testEmailAddress = TestEmailAddress;
            if (string.IsNullOrWhiteSpace(testEmailAddress))
            {
                r.AddError(ERROR_MISSING_PROPERTY, $"{nameof(TestEmailAddress)} was not set on {GetType().Name}");
                return toEmails;
            }

            // Try to get the environment replacement token, return if we fail.
            var testEmailEnvToken = TestEmailEnvironmentToken;
            if (string.IsNullOrWhiteSpace(testEmailEnvToken))
            {
                r.AddError(ERROR_MISSING_PROPERTY, $"{nameof(TestEmailEnvironmentToken)} was not set on {typeof(EmailSettings).Name}");
                return toEmails;
            }

            testEmailAddress = testEmailAddress.Replace(testEmailEnvToken, environmentName?.ToLower() ?? "unknown");

            toEmails.Add(testEmailAddress);

            return toEmails;
        })
        .Result;

        #endregion Public Methods
    }
}
