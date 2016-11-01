using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuitCase
{
    public partial class Conventions
    {

        public class DotNet
        {

            public static CasingSyntax Assembly => Syntaxes.Pascal;

            public static CasingSyntax Namespace => Syntaxes.Pascal;

            public static CasingSyntax Class => Syntaxes.Pascal;

            public static CasingSyntax Interface => Syntaxes.Pascal;

            public static CasingSyntax Method => Syntaxes.Pascal;

            public static CasingSyntax Property => Syntaxes.Pascal;

            public static CasingSyntax Parameter => Syntaxes.Pascal;

            public static CasingSyntax Constant => Syntaxes.Pascal;

            public static CasingSyntax Enum => Syntaxes.Pascal;

            public static CasingSyntax EnumValue => Syntaxes.Pascal;

            public static CasingSyntax Event => Syntaxes.Pascal;

            public static CasingSyntax Variable => Syntaxes.Camel;

            public static CasingSyntax Field => Syntaxes.Camel;

        }

    }
}
