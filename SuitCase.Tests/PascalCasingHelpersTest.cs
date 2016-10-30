using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SuitCase.Tests
{
    public class PascalCasingHelpersTest
    {

        public static IEnumerable<object[]> FromData
        {
            get
            {
                return new List<object[]>
                {
                    new object[] { "SomeSimpleTestData", new [] { "some", "simple", "test", "data" } },
                    new object[] { "Single", new [] { "single", } },
                    new object[] { "StRaNgeCasIng", new [] { "st", "ra", "nge", "cas", "ing" } }
                };
            }
        }

        [Theory]
        [MemberData("FromData")]
        public void ConvertsFromPascalCorrectly(string input, string[] expected)
        {
            CasingContext result = input.FromPascal();

            List<string> terms = result.Terms.ToList();

            Assert.Equal(terms.Count, expected.Length);
            for (var i = 0; i < terms.Count; i++)
            {
                Assert.Equal(expected[i], terms[i]);
            }
        }

        public static IEnumerable<object[]> ToData
        {
            get
            {
                return new List<object[]>
                {
                    new object[] { new CasingContext(new[] { "some", "simple", "test", "data" }), "SomeSimpleTestData" },
                    new object[] { new CasingContext(new[] { "single" }), "Single" },
                    new object[] { new CasingContext(new[] { "st", "ra", "nge", "cas", "ing" }), "StRaNgeCasIng" }
                };
            }
        }

        [Theory]
        [MemberData("ToData")]
        public void ConvertsToPascalCorrectly(CasingContext input, string expected)
        {
            string result = input.ToPascal();

            Assert.Equal(expected, result);
        }

    }
}
