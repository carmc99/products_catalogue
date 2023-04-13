using System;

namespace products_catalogue.Utils
{
    public static class GuidParser
    {
        public static bool IsValidGuid(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            // Intentar convertir el input a un Guid y verificar si es válido
            return Guid.TryParse(input, out _);
        }
    }
}