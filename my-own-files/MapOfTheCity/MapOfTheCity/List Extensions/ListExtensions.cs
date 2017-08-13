using System;
using System.Collections.Generic;
using System.Linq;

namespace MapOfTheCity
{
    public static class ListExtensions
    {
        public static string EmptyIfNull(this string value) {
            return value ?? string.Empty;
        }

        public static bool IsEmpty<T>(this List<T> list)
        {
            return list.Count() == 0;
        }

        public static bool IsIndexInRange(this int index, int placesCount)
        {
            if (index >= 0 && index < placesCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
