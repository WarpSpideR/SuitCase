using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuitCase
{

    /// <summary>
    /// Defines the syntax of a capitalisation scheme
    /// </summary>
    public class CasingSyntax
    {

        /// <summary>
        /// Termination type used between terms
        /// </summary>
        public TermTermination TerminationType { get; set; }

        /// <summary>
        /// Termination character used when <see cref="TerminationType"/>
        /// is set to <see cref="TermTermination.Character"/>
        /// </summary>
        public char Terminator { get; set; }

        /// <summary>
        /// Determines whether the termination character is
        /// included in the term
        /// </summary>
        public bool IncludeTerminator { get; set; }

        /// <summary>
        /// Determines how terms are caplitalised
        /// </summary>
        public Capitalisation Capitalisation { get; set; }

        /// <summary>
        /// Characters applied to start of phrase
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Characters applied to end of phrase
        /// </summary>
        public string Suffix { get; set; }

    }
}
