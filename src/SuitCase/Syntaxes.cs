using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuitCase
{
    public class Syntaxes
    {

        /// <summary>
        /// Syntax for camelCasing
        /// </summary>
        public static CasingSyntax Camel => new CasingSyntax()
        {
            TerminationType = TermTermination.Uppercase,
            Terminator = '\0',
            IncludeTerminator = true,
            Capitalisation = Capitalisation.LowerThenTitle,
            Prefix = null,
            Suffix = null
        };

        /// <summary>
        /// Syntax for kebab-casing
        /// </summary>
        public static CasingSyntax Kebab => new CasingSyntax()
        {
            TerminationType = TermTermination.Character,
            Terminator = '-',
            IncludeTerminator = false,
            Capitalisation = Capitalisation.Lower,
            Prefix = null,
            Suffix = null
        };

        /// <summary>
        /// Syntax for PascalCasing
        /// </summary>
        public static CasingSyntax Pascal => new CasingSyntax()
        {
            TerminationType = TermTermination.Uppercase,
            Terminator = '\0',
            IncludeTerminator = true,
            Capitalisation = Capitalisation.Title,
            Prefix = null,
            Suffix = null
        };

        /// <summary>
        /// Syntax for Snake_Casing
        /// </summary>
        public static CasingSyntax Snake => new CasingSyntax()
        {
            TerminationType = TermTermination.Character,
            Terminator = '_',
            IncludeTerminator = false,
            Capitalisation = Capitalisation.Lower,
            Prefix = null,
            Suffix = null
        };

    }
}
