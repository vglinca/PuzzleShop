using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzleShop.Core.Extensions
{
	public static class DateTimeExtensions
	{
        public static int GetCurrentAge(this DateTime date)
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
