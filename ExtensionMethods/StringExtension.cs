using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ArktiPhones.Extensions
{
    public static class StringExtensions
    {
        public static double? ToNullableDouble(this string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString)) return null;

            double? nullableResult = null;
            if (double.TryParse(inputString, out var result))
                nullableResult = result;
            return result;
        }

         public static int? ToNullableInt(this string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString)) return null;
            
            int? nullableResult = null;
            if (int.TryParse(inputString, out var result))
                nullableResult = result;
            return result;
        }
    }

}