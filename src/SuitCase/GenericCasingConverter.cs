using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuitCase
{

    /// <summary>
    /// Class that can transform between different syntaxes
    /// </summary>
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
        /// Converts a string into its invarient cased terms
        /// </summary>
        /// <param name="input">Phrase to convert</param>
        /// <returns>Invarient cased phrase</returns>
        public CasingContext FromCase(string input)
        {
            List<string> parts = new List<string>();
            string part = string.Empty;
            
            input = RemovePrefix(input, Syntax);
            input = RemoveSuffix(input, Syntax);

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

        /// <summary>
        /// Converts from the current syntax case to a given syntax
        /// </summary>
        /// <param name="input">Phrase to convert</param>
        /// <param name="syntax">Syntax to convert to</param>
        /// <returns>Converted phrase</returns>
        public string ToCase(string input, CasingSyntax syntax)
        {
            CasingContext context = FromCase(input);
            return ToCase(context, syntax);
        }

        /// <summary>
        /// Converts from invarient case to that specified in <see cref="Syntax"/>
        /// </summary>
        /// <param name="context">Invarient cased phrase</param>
        /// <returns>Converted phrase</returns>
        public string ToCase(CasingContext context)
        {
            return ToCase(context, Syntax);
        }

        /// <summary>
        /// Converts from invarient cased pharse to the given syntax
        /// </summary>
        /// <param name="context">Phrase to convert</param>
        /// <param name="syntax">Syntax to use</param>
        /// <returns>Converted phrase</returns>
        public string ToCase(CasingContext context, CasingSyntax syntax)
        {
            string result = ApplyPrefix(syntax);
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

            result = ApplySuffix(result, syntax);

            return result;
        }

        /// <summary>
        /// Removes any prefixes from the input
        /// </summary>
        /// <param name="input">Input</param>
        /// <param name="syntax">Syntax to use</param>
        /// <returns>Input without any prefixes</returns>
        private string RemovePrefix(string input, CasingSyntax syntax)
        {
            if (string.IsNullOrEmpty(syntax.Prefix))
            {
                return input;
            }
            if (input.StartsWith(syntax.Prefix))
            {
                return input.Substring(syntax.Prefix.Length);
            }
            return input;
        }

        /// <summary>
        /// Applies any prefixes from the input
        /// </summary>
        /// <param name="syntax">Syntax to use</param>
        /// <returns>Input with any prefixes</returns>
        private string ApplyPrefix(CasingSyntax syntax)
        {
            return ApplyPrefix(string.Empty, syntax);
        }

        /// <summary>
        /// Applies any prefixes from the input
        /// </summary>
        /// <param name="input">Input</param>
        /// <param name="syntax">Syntax to use</param>
        /// <returns>Input with any prefixes</returns>
        private string ApplyPrefix(string input, CasingSyntax syntax)
        {
            if (!string.IsNullOrEmpty(syntax.Prefix))
            {
                return syntax.Prefix + input;
            }
            return input;
        }

        /// <summary>
        /// Removes any suffixes from the input
        /// </summary>
        /// <param name="input">Input</param>
        /// <param name="syntax">Syntax to use</param>
        /// <returns>Input without any suffixes</returns>
        private string RemoveSuffix(string input, CasingSyntax syntax)
        {
            if (string.IsNullOrEmpty(syntax.Suffix))
            {
                return input;
            }
            if (input.EndsWith(syntax.Suffix))
            {
                return input.Substring(0, input.Length - syntax.Suffix.Length);
            }
            return input;
        }
        
        /// <summary>
        /// Applies any suffixes from the input
        /// </summary>
        /// <param name="input">Input</param>
        /// <param name="syntax">Syntax to use</param>
        /// <returns>Input with any suffixes</returns>
        private string ApplySuffix(string input, CasingSyntax syntax)
        {
            if (!string.IsNullOrEmpty(syntax.Suffix))
            {
                return input + syntax.Suffix;
            }
            return input;
        }

        /// <summary>
        /// Applies capitalisation to a term
        /// </summary>
        /// <param name="term">Term to capitalise</param>
        /// <param name="syntax">Syntax to use</param>
        /// <param name="index">Index in pharse</param>
        /// <returns>Capitalised term</returns>
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

        /// <summary>
        /// Applys the relevant terminator to the given term
        /// </summary>
        /// <param name="term">Term to be terminated</param>
        /// <param name="syntax">Syntax to use</param>
        /// <returns>Terminated term</returns>
        private string ApplyTerminator(string term, CasingSyntax syntax)
        {
            switch (Syntax.TerminationType)
            {
                case TermTermination.Uppercase:
                    return char.ToUpper(term[0]) + term.Substring(1);
                case TermTermination.Character:
                    return syntax.Terminator + term;
                default:
                    throw new InvalidOperationException("Unknown Term Termination");
            }
        }

        /// <summary>
        /// Determines whether the given character is a terminator
        /// </summary>
        /// <param name="character">Character to test</param>
        /// <returns>True if a terminator, false otherwise</returns>
        protected bool IsTerminator(char character)
        {
            switch (Syntax.TerminationType)
            {
                case TermTermination.Uppercase:
                    return char.IsUpper(character);
                case TermTermination.Character:
                    return character == Syntax.Terminator;
                default:
                    throw new InvalidOperationException("Unknown Term Termination");
            }
        }
    }
}
