using System;
using System.Collections.Generic;
using System.Text;
using Shouldly;
using Xunit;


namespace AndcultureCode.CSharp.Extensions.Tests
{
    public class DateExtensionsTests
    {
        #region AtMidnight

        [Fact]
        public void AtMidnight_Returns_Date_With_Time_Set_To_Midnight()
        {
            // Arrange
            var testDate = DateTimeOffset.Now;

            // Act
            var result = testDate.AtMidnight();

            // Assert
            result.Hour.ShouldBe(0);
            result.Minute.ShouldBe(0);
            result.Second.ShouldBe(0);

        }

        [Fact]
        public void AtMidnight_Preserves_The_Offset_Value()
        {
            // Arrange
            var testDate = DateTimeOffset.Now;

            // Act
            var result = testDate.AtMidnight();

            // Assert
            result.Offset.ShouldBe(testDate.Offset);
        }

        [Fact]
        public void AtMidnight_Does_Not_Change_The_Date()
        {
            // Arrange
            var testDate = DateTimeOffset.Now;

            // Act
            var result = testDate.AtMidnight();

            // Assert
            result.Year.ShouldBe(testDate.Year);
            result.Month.ShouldBe(testDate.Month);
            result.Day.ShouldBe(testDate.Day);
        }

        #endregion
    }
}
