using System;
using System.Collections.Generic;

namespace KataStringCalculator
{
    public static class Extensions
    {
        public static bool IsNegativeValue(this int value)
        {
            return value < 0;
        }

        public static bool IsValueBiggerThanThousand(this int value)
        {
            return value > 1000;
        }

        public static bool IsThereError(this IReadOnlyCollection<int> errors)
        {
            return errors.Count > 0;
        }

        public static int ToInteger(this string value)
        {
            return Convert.ToInt32(value);
        }

        public static string PrepareErrorMessage(this IEnumerable<int> errors)
        {
            return String.Format("Negatives not allowed: {0}", String.Join(",", errors));
        }
    }
}