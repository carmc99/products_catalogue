using System;

namespace products_catalogue.Utils
{
    public static class GuidParser
    {
        public static bool ParseStringToGuid(string input, out Guid guidOutput)
        {
            guidOutput = Guid.Empty;

            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            if (Guid.TryParse(input, out Guid parsedGuid))
            {
                // Si el input es un Guid válido
                guidOutput = parsedGuid;
                return true;
            }
            else
            {
                return false;
            }
        }

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