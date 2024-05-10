using System;

namespace RSM.HCD.CSharp.Extensions
{
    /// <summary>
    /// DateTime/Offset Extensions
    /// </summary>
    public static class DateExtensions
    {
        /// <summary>
        /// Sets and returns the time to 11:59:59 on the given DateTimeOffset.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTimeOffset AtEndOfDay(this DateTimeOffset date) => SetTime(date, 23, 59, 59);

        /// <summary>
        /// Useful when you only care about the date, but do not want to lose the offset.
        /// Returns the midnight representation of the given DateTimeOffset.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTimeOffset AtMidnight(this DateTimeOffset date) => SetTime(date, 0, 0, 0);

        /// <summary>
        /// Convenience method to calculate an age from a birthdate
        /// </summary>
        public static int CalculateAge(this DateTime birthdate)
        {
            var age = DateTime.Today.Year - birthdate.Year;
            // Subtract a year if the birthday has not happened yet this year
            // https://stackoverflow.com/questions/9/how-do-i-calculate-someones-age-in-c
            if (birthdate > DateTime.Today.AddYears(-age))
            {
                age--;
            }
            return age;
        }

        /// <summary>
        /// Sets the hour, minute, and second on the given DateTimeOffset with the supplied values.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static DateTimeOffset SetTime(this DateTimeOffset date, int hour, int minute, int second)
        {
            if (hour < 0 || hour > 23)
            {
                throw new ArgumentException($"Hour: {hour} is invalid. It must be between 0 and 23.", nameof(hour));
            }

            if (minute < 0 || minute > 59)
            {
                throw new ArgumentException($"Minute: {minute} is invalid. It must be between 0 and 59.", nameof(minute));
            }

            if (second < 0 || second > 59)
            {
                throw new ArgumentException($"Second: {second} is invalid. It must be between 0 and 59.", nameof(second));
            }

            return new DateTimeOffset(
                year: date.Year,
                month: date.Month,
                day: date.Day,
                hour: hour,
                minute: minute,
                second: second,
                offset: date.Offset);
        }

        /// <summary>
        /// Convenience method to subtract weekdays
        /// </summary>
        public static DateTime SubtractWeekdays(this DateTime originalDate, int weekdays)
        {
            var tmpDate = originalDate;
            while (weekdays > 0)
            {
                tmpDate = tmpDate.AddDays(-1);
                if (tmpDate.DayOfWeek < DayOfWeek.Saturday &&
                    tmpDate.DayOfWeek > DayOfWeek.Sunday)
                {
                    weekdays--;
                }
            }
            return tmpDate;
        }

        /// <summary>
        /// Convenience method to subtract weekdays
        /// </summary>
        public static DateTimeOffset SubtractWeekdays(this DateTimeOffset originalDate, int weekdays)
        {
            var tmpDate = originalDate;
            while (weekdays > 0)
            {
                tmpDate = tmpDate.AddDays(-1);
                if (tmpDate.DayOfWeek < DayOfWeek.Saturday &&
                    tmpDate.DayOfWeek > DayOfWeek.Sunday)
                {
                    weekdays--;
                }
            }
            return tmpDate;
        }

        /// <summary>
        /// Convenience method to default the inclusive parameter
        /// LINQ doesn't like optional parameters on methods used in expressions
        /// </summary>
        public static bool IsBetweenDates(this DateTimeOffset date, DateTimeOffset minDate, DateTimeOffset maxDate)
        {
            return date.IsBetweenDates(minDate, maxDate, true);
        }

        /// <summary>
        /// Provides filtering method for date ranges (excluding time portions)
        /// </summary>
        public static bool IsBetweenDates(this DateTimeOffset date, DateTimeOffset minDate, DateTimeOffset maxDate, bool inclusive)
        {
            if (inclusive)
            {
                return date.IsBetweenDatesInclusive(minDate, maxDate);
            }

            return date.IsBetweenDatesExclusive(minDate, maxDate);
        }

        #region Private Methods

        private static bool IsBetweenDatesInclusive(this DateTimeOffset date, DateTimeOffset minDate, DateTimeOffset maxDate)
        {
            return minDate <= date && date <= maxDate;
        }

        private static bool IsBetweenDatesExclusive(this DateTimeOffset date, DateTimeOffset minDate, DateTimeOffset maxDate)
        {
            return minDate < date && date < maxDate;
        }

        #endregion
    }
}
