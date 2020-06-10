using System;
using AndcultureCode.CSharp.Core.Enumerations;

namespace AndcultureCode.CSharp.Core.Models.Entities.Worker
{
    /// <summary>
    /// Recurrance configuration for a given worker
    /// </summary>
    public class RecurringOption
    {
        public int Day { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Month { get; set; }
        public Recurrence Recurrence { get; set; }
    }
}