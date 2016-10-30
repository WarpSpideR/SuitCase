using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuitCase
{
    public static class PascalCaseHelpers
    {

        public static CasingContext FromPascal(this string input)
        {
            return CasingContext.Empty;
        }

        public static string ToPascal(this CasingContext input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if (input == CasingContext.Empty)
                return input.ToString();

            throw new NotImplementedException();
        }

    }
}
