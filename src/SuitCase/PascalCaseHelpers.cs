using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuitCase
{
    public static class PascalCaseHelpers
    {

        /// <summary>
        /// Converts from Pascal Casing
        /// </summary>
        /// <param name="input">Pascal Casing formatted string</param>
        /// <returns>Case insensitive result</returns>
        public static CasingContext FromPascal(this string input)
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
                if (char.IsUpper(letter))
                {
                    parts.Add(part);
                    part = char.ToLower(input[index]).ToString();
                }
                else
                {
                    part += input[index];
                }
            }

            if (part.Length > 0)
            {
                parts.Add(part);
            }

            return new CasingContext(parts);
        }

        /// <summary>
        /// Converts to Pascal Casing
        /// </summary>
        /// <param name="input">Casing insensitive input</param>
        /// <returns>Pascal case formatted string</returns>
        public static string ToPascal(this CasingContext input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if (input == CasingContext.Empty)
                return input.ToString();

            var result = string.Empty;

            foreach (string part in input.Terms)
            {
                result += char.ToUpper(part[0]);
                result += part.Substring(1);
            }

            return result;
        }

    }
}
