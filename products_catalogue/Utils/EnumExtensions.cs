using System;

namespace products_catalogue.Utils
{
    public static class EnumExtensions
    {
        public static T StringToEnum<T>(string inputString) where T : struct, Enum
        {
            T enumValue;
            Enum.TryParse<T>(inputString, true, out enumValue);
            return enumValue;
        }
        public static bool IsValid<T>(string inputString) where T : struct, Enum
        {
            if (String.IsNullOrEmpty(inputString))
            {
                return false;
            }
            bool isValid = Enum.TryParse<T>(inputString, true, out _);
            return isValid;
        }
    }
}