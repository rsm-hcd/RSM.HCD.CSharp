using System.IO;
using System.Text;
using Xunit.Abstractions;

namespace RSM.HCD.CSharp.Logging
{
    public class XUnitTestOutputConverter : TextWriter
    {
        #region Properties

        public override Encoding Encoding { get => Encoding.ASCII; }

        private ITestOutputHelper _output;

        #endregion Properties


        #region Constructors

        public XUnitTestOutputConverter(ITestOutputHelper output)
        {
            _output = output;
        }

        #endregion Constructors


        #region Public Methods

        public override void WriteLine(string message)
        {
            try
            {
                _output.WriteLine(message);
            }
            catch
            {
            }
        }

        public override void WriteLine(string format, params object[] args)
        {
            try
            {
                _output.WriteLine(format, args);
            }
            catch
            {
            }
        }

        #endregion Public Methods
    }
}
