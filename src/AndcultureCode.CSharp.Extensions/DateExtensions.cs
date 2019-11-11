using System;
using System.Collections.Generic;
using System.Text;

namespace AndcultureCode.CSharp.Extensions
{
    public static class DateExtensions
    {
        /// <summary>
        /// Useful when you only care about the date, but do not want to lose the offset.
        /// Returns the midnight representation of the given DateTimeOffset.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTimeOffset AtMidnight(this DateTimeOffset date)
        {
            return new DateTimeOffset(
                year: date.Year,
                month: date.Month,
                day: date.Day,
                hour: 0,
                minute: 0,
                second: 0,
                offset: date.Offset);
        }
    }
}
