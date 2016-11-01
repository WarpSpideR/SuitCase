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
        [InlineData("__someSimpleTestData", TermTermination.Uppercase, ' ', true, "__")]
        [InlineData("__Some_Simple_Test_Data", TermTermination.Character, '_', false, "__")]
        [InlineData("[Some_Simple_Test_Data", TermTermination.Character, '_', false, "[")]
        [InlineData("   Some Simple Test Data", TermTermination.Character, ' ', false, "   ")]
        [InlineData("Some Simple Test Data", TermTermination.Character, ' ', false, "")]
        [InlineData("Some Simple Test Data", TermTermination.Character, ' ', false, null)]
        public void FromCaseRespectsPrefix(string input, TermTermination terminationType, char terminationChar, bool includeTerminator, string prefix)
        {
            CasingSyntax syntax = new CasingSyntax()
            {
                TerminationType = terminationType,
                Terminator = terminationChar,
                IncludeTerminator = includeTerminator,
                Prefix = prefix
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
        [InlineData("someSimpleTestData__", TermTermination.Uppercase, ' ', true, "__")]
        [InlineData("Some_Simple_Test_Data__", TermTermination.Character, '_', false, "__")]
        [InlineData("Some_Simple_Test_Data]", TermTermination.Character, '_', false, "]")]
        [InlineData("Some Simple Test Data   ", TermTermination.Character, ' ', false, "   ")]
        [InlineData("Some Simple Test Data", TermTermination.Character, ' ', false, "")]
        [InlineData("Some Simple Test Data", TermTermination.Character, ' ', false, null)]
        public void FromCaseRespectsSuffix(string input, TermTermination terminationType, char terminationChar, bool includeTerminator, string suffix)
        {
            CasingSyntax syntax = new CasingSyntax()
            {
                TerminationType = terminationType,
                Terminator = terminationChar,
                IncludeTerminator = includeTerminator,
                Suffix = suffix
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

    }
}
