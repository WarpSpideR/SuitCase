using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SuitCase.Tests
{
    public partial class GenericCasingConverterTest
    {

        [Theory]
        [InlineData("SomeSimpleTestData", TermTermination.Uppercase, ' ', true, Capitalisation.Title)]
        [InlineData("someSimpleTestData", TermTermination.Uppercase, ' ', true, Capitalisation.LowerThenTitle)]
        [InlineData("some-simple-test-data", TermTermination.Character, '-', false, Capitalisation.Lower)]
        [InlineData("Some_Simple_Test_Data", TermTermination.Character, '_', false, Capitalisation.Title)]
        [InlineData("Some Simple Test Data", TermTermination.Character, ' ', false, Capitalisation.Title)]
        public void ToCaseRespectsTermination(string output, TermTermination terminationType, char terminationChar, bool includeTerminator, Capitalisation capitalisation)
        {
            CasingSyntax syntax = new CasingSyntax()
            {
                TerminationType = terminationType,
                Terminator = terminationChar,
                IncludeTerminator = includeTerminator,
                Capitalisation = capitalisation
            };
            GenericCasingConverter converter = new GenericCasingConverter(syntax);

            CasingContext context = new CasingContext(new[] { "some", "simple", "test", "data" });

            string result = converter.ToCase(context);

            Assert.Equal(output, result);
        }

        [Theory]
        [InlineData("__SomeSimpleTestData", TermTermination.Uppercase, ' ', true, Capitalisation.Title, "__")]
        [InlineData("--someSimpleTestData", TermTermination.Uppercase, ' ', true, Capitalisation.LowerThenTitle, "--")]
        [InlineData("some-simple-test-data", TermTermination.Character, '-', false, Capitalisation.Lower, null)]
        [InlineData("Some_Simple_Test_Data", TermTermination.Character, '_', false, Capitalisation.Title, "")]
        [InlineData(" Some Simple Test Data", TermTermination.Character, ' ', false, Capitalisation.Title, " ")]
        public void ToCaseRespectsPrefix(string output, TermTermination terminationType, char terminationChar, bool includeTerminator, Capitalisation capitalisation, string prefix)
        {
            CasingSyntax syntax = new CasingSyntax()
            {
                TerminationType = terminationType,
                Terminator = terminationChar,
                IncludeTerminator = includeTerminator,
                Capitalisation = capitalisation,
                Prefix = prefix
            };
            GenericCasingConverter converter = new GenericCasingConverter(syntax);

            CasingContext context = new CasingContext(new[] { "some", "simple", "test", "data" });

            string result = converter.ToCase(context);

            Assert.Equal(output, result);
        }

    }
}
