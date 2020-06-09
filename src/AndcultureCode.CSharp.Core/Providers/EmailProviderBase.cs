using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Providers.Mail;
using MimeKit;

namespace AndcultureCode.CSharp.Core.Providers
{
    /// <summary>
    /// Base abstract class to provide email provider functionality
    /// </summary>
    public abstract class EmailProviderBase : Provider, IEmailProvider
    {
        #region Public Methods

        /// <summary>
        /// Deliver a message now
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public abstract IResult<bool> Send(MimeMessage message);

        /// <summary>
        /// Deliver a message later (via background jobs likely)
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public abstract IResult<bool> SendLater(MimeMessage message);

        #endregion Public Methods
    }
}
