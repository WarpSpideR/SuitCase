using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuitCase
{
    public class GenericCasingConverter
    {

        /// <summary>
        /// Current Syntax to use when converting
        /// </summary>
        protected CasingSyntax Syntax { get; private set; }

        /// <summary>
        /// Creates a new converter instance for a given syntax
        /// </summary>
        /// <param name="syntax">Casing syntax to use when converting</param>
        public GenericCasingConverter(CasingSyntax syntax)
        {
            Syntax = syntax;
        }

        /// <summary>
        /// Converts a string into its 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public CasingContext FromCase(string input)
        {
            List<string> parts = new List<string>();
            string part = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (i > 0 && IsTerminator(currentChar))
                {
                    parts.Add(part);
                    part = Syntax.IncludeTerminator ? char.ToLower(currentChar).ToString() : string.Empty;
                }
                else
                {
                    part += char.ToLower(currentChar);
                }
            }

            if (!string.IsNullOrWhiteSpace(part))
                parts.Add(part);

            return new CasingContext(parts);
        }

        public string ToCase(CasingContext context)
        {
            return ToCase(context, Syntax);
        }

        public string ToCase(string input, CasingSyntax syntax)
        {
            throw new NotImplementedException();
        }

        protected string ToCase(CasingContext context, CasingSyntax syntax)
        {
            string result = string.Empty;
            var index = 0;

            foreach (string rawTerm in context.Terms)
            {
                string term = rawTerm;

                term = ApplyCapitalisation(term, syntax, index);

                if (index > 0)
                {
                    term = ApplyTerminator(term, syntax);
                }

                result += term;
                index++;
            }

            return result;
        }

        private string ApplyCapitalisation(string term, CasingSyntax syntax, int index)
        {
            switch (syntax.Capitalisation)
            {
                case Capitalisation.Lower:
                    return term;
                case Capitalisation.LowerThenTitle:
                    if (index > 0)
                        return char.ToUpper(term[0]) + term.Substring(1);
                    return term;
                case Capitalisation.Title:
                    return char.ToUpper(term[0]) + term.Substring(1);
                case Capitalisation.Upper:
                    return term.ToUpper();
                default:
                    throw new InvalidOperationException("Unknown Capitalisation Method");
            }
        }

        private string ApplyTerminator(string term, CasingSyntax syntax)
        {
            switch (Syntax.TerminationType)
            {
                case TermTermination.Uppercase:
                    return char.ToUpper(term[0]) + term.Substring(1);
                case TermTermination.Character:
                    return syntax.Terminator + term;
                default:
                    throw new InvalidOperationException("Invalid Term Termination");
            }
        }

        protected bool IsTerminator(char character)
        {
            switch (Syntax.TerminationType)
            {
                case TermTermination.Uppercase:
                    return char.IsUpper(character);
                case TermTermination.Character:
                    return character == Syntax.Terminator;
                default:
                    throw new InvalidOperationException("Invalid Term Termination");
            }
        }
    }
}
