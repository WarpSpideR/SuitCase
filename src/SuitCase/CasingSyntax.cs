using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuitCase
{
    public class CasingSyntax
    {

        public TermTermination TerminationType { get; set; }
        public char Terminator { get; set; }
        public bool IncludeTerminator { get; set; }
        public Capitalisation Capitalisation { get; set; }

    }
}
