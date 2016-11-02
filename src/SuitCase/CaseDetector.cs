using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuitCase
{
    public class CaseDetector
    {
        
        protected class PhraseStatistics
        {
            public bool FirstAlphaIsUpper { get; set; }
            public int Alpha { get; set; }
            public int AlphaUpper { get; set; }
            //public int AlphaUpperAfterLower { get; set; }
            //public int AlphaUpperAfterUpper { get; set; }
            public int Numeric { get; set; }
            public IDictionary<char, int> Chars { get; set; }

            public PhraseStatistics()
            {
                Chars = new Dictionary<char, int>();
            }
        }

        public CasingSyntax DetermineSyntax(string phrase)
        {
            PhraseStatistics stats = AnalysePhrase(phrase);
            
            CasingSyntax syntax = new CasingSyntax();
            syntax.Capitalisation = DeterminCapitalisation(stats);
            syntax.TerminationType = DetermineTerminationType(stats);
            syntax.Terminator = DetermineTerminator(stats);
            syntax.IncludeTerminator = syntax.TerminationType == TermTermination.Uppercase;
            syntax.Prefix = DeterminePrefix(stats);
            syntax.Suffix = DetermineSuffix(stats);

            return syntax;
        }

        private string DetermineSuffix(PhraseStatistics stats)
        {
            return null;
        }

        private string DeterminePrefix(PhraseStatistics stats)
        {
            return null;
        }

        private char DetermineTerminator(PhraseStatistics stats)
        {
            if (stats.Chars.Keys.Count == 0) return '\0';

            char maxChar = '\0';
            int maxCount = 0;
            foreach (KeyValuePair<char, int> entry in stats.Chars)
            {
                if (entry.Value > maxCount)
                {
                    maxChar = entry.Key;
                    maxCount = entry.Value;
                }
            }

            return maxChar;
        }

        private TermTermination DetermineTerminationType(PhraseStatistics stats)
        {
            if (stats.AlphaUpper > 0 && stats.AlphaUpper != stats.Alpha) return TermTermination.Uppercase;

            return TermTermination.Character;
        }

        private Capitalisation DeterminCapitalisation(PhraseStatistics stats)
        {
            if (stats.Alpha == stats.AlphaUpper) return Capitalisation.Upper;
            if (stats.Alpha > 0 && stats.AlphaUpper == 0) return Capitalisation.Lower;

            if (stats.FirstAlphaIsUpper)
                return Capitalisation.Title;

            return Capitalisation.LowerThenTitle;
        }

        protected PhraseStatistics AnalysePhrase(string phrase)
        {
            PhraseStatistics stats = new PhraseStatistics();
            //char last = '\0';
            bool firstAlpha = false;
            for (int i = 0; i < phrase.Length; i++)
            {
                char c = phrase[i];

                if (char.IsLetter(c))
                {
                    stats.Alpha++;
                    if (!firstAlpha)
                    {
                        firstAlpha = true;
                        stats.FirstAlphaIsUpper = char.IsUpper(c);
                    }
                }
                if (char.IsUpper(c)) stats.AlphaUpper++;
                if (char.IsNumber(c)) stats.Numeric++;
                if (char.IsSymbol(c) || char.IsPunctuation(c))
                {
                    if (!stats.Chars.ContainsKey(c))
                        stats.Chars.Add(c, 0);
                    stats.Chars[c]++;
                }
                //if (char.IsLetter(c) && char.IsLetter(last))
                //{
                //    bool cUpper = char.IsUpper(c);
                //    bool lastUpper = char.IsUpper(last);

                //    if (cUpper && lastUpper) stats.AlphaUpperAfterUpper++;
                //    if (cUpper && !lastUpper) stats.AlphaUpperAfterLower++;
                //}
            }

            return stats;
        }

    }
}
