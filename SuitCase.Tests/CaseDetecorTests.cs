using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SuitCase.Tests
{
    public class CaseDetecorTests
    {

        [Theory]
        [InlineData("SomeSimpleTestData", TermTermination.Uppercase, '\0')]
        [InlineData("someSimpleTestData", TermTermination.Uppercase, '\0')]
        [InlineData("some-simple-test-data", TermTermination.Character, '-')]
        [InlineData("SOME_SIMPLE_TEST_DATA", TermTermination.Character, '_')]
        public void DeterminesUpperTerminationCorrectly(string input, TermTermination terminationType, char terminationChar)
        {
            CaseDetector detector = new CaseDetector();

            CasingSyntax result = detector.DetermineSyntax(input);

            Assert.Equal(terminationType, result.TerminationType);
            Assert.Equal(terminationChar, result.Terminator);
        }

        [Theory]
        [InlineData("SomeSimpleTestData", Capitalisation.Title)]
        [InlineData("someSimpleTestData", Capitalisation.LowerThenTitle)]
        [InlineData("some-simple-test-data", Capitalisation.Lower)]
        [InlineData("SOME_SIMPLE_TEST_DATA", Capitalisation.Upper)]
        public void DeterminesCapitalisationCorrectly(string input, Capitalisation expected)
        {
            CaseDetector detector = new CaseDetector();

            CasingSyntax result = detector.DetermineSyntax(input);

            Assert.Equal(expected, result.Capitalisation);
        }

    }
}
