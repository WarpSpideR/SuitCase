using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuitCase
{

    /// <summary>
    /// Represents a phrase broken down into its casing 
    /// insensitive constituent parts
    /// </summary>
    public class CasingContext
    {

        /// <summary>
        /// Represents an empty phrase
        /// </summary>
        public static CasingContext Empty => new CasingContext();

        /// <summary>
        /// Backing storage for terms
        /// </summary>
        protected readonly string[] TermsLocal;

        /// <summary>
        /// Casing insensitive terms of a phrase
        /// </summary>
        public IEnumerable<string> Terms { get { return TermsLocal; } }

        /// <summary>
        /// Creates a new empty instance of a casing insensitive phrase
        /// </summary>
        private CasingContext()
        {
            TermsLocal = new string[0];
        }

        /// <summary>
        /// Creates a new instance of a casing insensitive phrase
        /// </summary>
        public CasingContext(IEnumerable<string> terms)
        {
            TermsLocal = terms.ToArray();
        }
        
    }
}
