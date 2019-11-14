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

        #region CalculateAge

        [Fact]
        public void CalculateAge_Returns_Correct_Age_If_Birthday_Has_Happened_This_Year()
        {
            // Arrange
            var birthdate = DateTime.Today.AddMonths(1);
            birthdate = birthdate.AddYears(-5);

            // Act
            var result = birthdate.CalculateAge();

            // Assert
            result.ShouldBe(4);
        }

        [Fact]
        public void CalculateAge_Returns_Correct_Age_If_Birthday_Has_Not_Happened_This_Year()
        {
            // Arrange
            var birthdate = DateTime.Today.AddMonths(-1);
            birthdate = birthdate.AddYears(-5);

            // Act
            var result = birthdate.CalculateAge();

            // Assert
            result.ShouldBe(5);
        }

        #endregion

        #region SubtractWeekdays -- DateTime


        [Fact]
        public void SubtractWeekdays_Returns_Correctly_When_Day_Is_In_The_Same_Week()
        {
            // Arrange
            var day = new DateTime(2019, 11, 14);

            // Act
            var result = day.SubtractWeekdays(3);

            // Assert
            result.DayOfWeek.ShouldBe(DayOfWeek.Monday);
        }

        [Fact]
        public void SubtractWeekdays_Returns_Correctly_When_Day_Is_In_A_Different_Week()
        {
            // Arrange
            var day = new DateTime(2019, 11, 14);

            // Act
            var result = day.SubtractWeekdays(5);

            // Assert
            result.DayOfWeek.ShouldBe(DayOfWeek.Thursday);
        }

        [Fact]
        public void SubtractWeekdays_Returns_Correctly_When_Starting_Point_Is_A_Weekend_Day()
        {
            // Arrange
            var day = new DateTime(2019, 11, 16);

            // Act
            var result = day.SubtractWeekdays(5);

            // Assert
            result.DayOfWeek.ShouldBe(DayOfWeek.Monday);
        }

        #endregion

        #region SubtractWeekdays -- DateTimeOffset


        [Fact]
        public void SubtractWeekdays_With_Offset_Returns_Correctly_When_Day_Is_In_The_Same_Week()
        {
            // Arrange
            var day = new DateTime(2019, 11, 14);
            var dateWithOffset = new DateTimeOffset(day);

            // Act
            var result = dateWithOffset.SubtractWeekdays(3);

            // Assert
            result.DayOfWeek.ShouldBe(DayOfWeek.Monday);
        }

        [Fact]
        public void SubtractWeekdays_With_Offset_Returns_Correctly_When_Day_Is_In_A_Different_Week()
        {
            // Arrange
            var day = new DateTime(2019, 11, 14);
            var dateWithOffset = new DateTimeOffset(day);

            // Act
            var result = dateWithOffset.SubtractWeekdays(5);

            // Assert
            result.DayOfWeek.ShouldBe(DayOfWeek.Thursday);
        }

        [Fact]
        public void SubtractWeekdays_With_Offset_Returns_Correctly_When_Starting_Point_Is_A_Weekend_Day()
        {
            // Arrange
            var day = new DateTime(2019, 11, 16);
            var dateWithOffset = new DateTimeOffset(day);

            // Act
            var result = dateWithOffset.SubtractWeekdays(5);

            // Assert
            result.DayOfWeek.ShouldBe(DayOfWeek.Monday);
        }

        #endregion
    }
}
