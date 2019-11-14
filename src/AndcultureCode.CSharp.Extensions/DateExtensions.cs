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

        /// <summary>
        /// Convenience method to calculate an age from a birthdate
        /// </summary>
        public static int CalculateAge(this DateTime birthdate)
        {
            var age = DateTime.Today.Year - birthdate.Year;
            // Subtract a year if the birthday has not happened yet this year
            // https://stackoverflow.com/questions/9/how-do-i-calculate-someones-age-in-c
            if (birthdate > DateTime.Today.AddYears(-age)) age--;
            return age;
        }

        /// <summary>
        /// Convenience method to subtract weekdays
        /// </summary>
        public static DateTime SubtractWeekdays(this DateTime originalDate, int weekdays)
        {
            DateTime tmpDate = originalDate;
            while (weekdays > 0)
            {
                tmpDate = tmpDate.AddDays(-1);
                if (tmpDate.DayOfWeek < DayOfWeek.Saturday &&
                    tmpDate.DayOfWeek > DayOfWeek.Sunday)
                    weekdays--;
            }
            return tmpDate;
        }

        /// <summary>
        /// Convenience method to subtract weekdays
        /// </summary>
        public static DateTimeOffset SubtractWeekdays(this DateTimeOffset originalDate, int weekdays)
        {
            DateTimeOffset tmpDate = originalDate;
            while (weekdays > 0)
            {
                tmpDate = tmpDate.AddDays(-1);
                if (tmpDate.DayOfWeek < DayOfWeek.Saturday &&
                    tmpDate.DayOfWeek > DayOfWeek.Sunday)
                    weekdays--;
            }
            return tmpDate;
        }
    }
}
