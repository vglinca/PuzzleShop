using System;

namespace PuzzleShop.Core.Extensions
{
    public static class DateTimeOffsetExtensions
    {
        public static int GetCurrentAge(this DateTimeOffset date)
        {
            var dateToCalculate = DateTime.UtcNow;
            var age = dateToCalculate.Year - date.Year;
            if (dateToCalculate < date.AddYears(age))
            {
                age--;
            }

            return age;
        }
    }
}