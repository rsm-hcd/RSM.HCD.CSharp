using System;
using Shouldly;

namespace RSM.HCD.CSharp.Core.Tests.Matchers
{
    public static class StringMatcherExtensions
    {
        /// <summary>
        /// Asserts whether the provided string is valid base64
        /// </summary>
        public static void ShouldBeBase64(this string str)
        {
            str.ShouldNotBeEmpty();

            var buffer = new Span<byte>(new byte[str.Length]);
            Convert.TryFromBase64String(str, buffer, out int bytesParsed);
        }
    }
}
