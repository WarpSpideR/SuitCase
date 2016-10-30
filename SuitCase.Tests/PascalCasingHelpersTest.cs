using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using SuitCase;

namespace SuitCase.Tests
{
    public class PascalCasingHelpersTest
    {

        [Fact]
        public void ConvertsToCasingContextCorrectly()
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

    }
}
