using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuitCase
{
    public static class KebabCasingHelpers
    {

        /// <summary>
        /// Converts from Kebab Casing
        /// </summary>
        /// <param name="input">Kebab Casing formatted string</param>
        /// <returns>Case insensitive result</returns>
        public static CasingContext FromKebabCase(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return CasingContext.Empty;

            var index = 0;
            var length = input.Length;
            string part = char.ToLower(input[index]).ToString();
            var parts = new List<string>();

            while (++index < length)
            {
                var letter = input[index];
                if (letter == '-')
                {
                    parts.Add(part);
                    part = string.Empty;
                }
                else
                {
                    part += char.ToLower(input[index]);
                }
            }

            if (part.Length > 0)
            {
                parts.Add(part);
            }

            return new CasingContext(parts);
        }

        /// <summary>
        /// Converts to Kebab Casing
        /// </summary>
        /// <param name="input">Casing insensitive input</param>
        /// <returns>Kebab case formatted string</returns>
        public static string ToKebabCase(this CasingContext input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if (input == CasingContext.Empty)
                return input.ToString();
            
            return string.Join("-", input.Terms);
        }

    }
}
