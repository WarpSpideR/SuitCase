using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SuitCase.Tests
{
    public class PascalCasingHelpersTest
    {

        [Fact]
        public void ConvertsFromPascalCorrectly()
        {
            string input = "SomeSimpleTestData";

            CasingContext result = input.FromPascal();

            List<string> terms = result.Terms.ToList();

            Assert.Equal(terms.Count, 4);
            Assert.Equal(terms[0], "some");
            Assert.Equal(terms[1], "simple");
            Assert.Equal(terms[2], "test");
            Assert.Equal(terms[3], "data");
        }

        [Fact]
        public void ConvertsToPascalCorrectly()
        {
            CasingContext context = new CasingContext(new[] { "some", "simple", "test", "data" });

            string result = context.ToPascal();

            Assert.Equal(result, "SomeSimpleTestData");
        }

    }
}
