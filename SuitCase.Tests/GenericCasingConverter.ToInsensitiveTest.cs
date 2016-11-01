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
        [InlineData("SomeSimpleTestData", TermTermination.Uppercase, ' ', true)]
        [InlineData("someSimpleTestData", TermTermination.Uppercase, ' ', true)]
        [InlineData("some-simple-test-data", TermTermination.Character, '-', false)]
        [InlineData("Some_Simple_Test_Data", TermTermination.Character, '_', false)]
        [InlineData("Some Simple Test Data", TermTermination.Character, ' ', false)]
        public void FromCaseRespectsTermination(string input, TermTermination terminationType, char terminationChar, bool includeTerminator)
        {
            CasingSyntax syntax = new CasingSyntax()
            {
                TerminationType = terminationType,
                Terminator = terminationChar,
                IncludeTerminator = includeTerminator
            };
            GenericCasingConverter converter = new GenericCasingConverter(syntax);

            CasingContext context = converter.FromCase(input);
            List<string> result = context.Terms.ToList();

            Assert.Equal(4, result.Count);
            Assert.Equal("some", result[0]);
            Assert.Equal("simple", result[1]);
            Assert.Equal("test", result[2]);
            Assert.Equal("data", result[3]);
        }

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

    }
}
