using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SuitCase.Tests
{
    public class CamelCasingHelpersTest
    {

        public static IEnumerable<object[]> FromData
        {
            get
            {
                return new List<object[]>
                {
                    new object[] { "someSimpleTestData", new [] { "some", "simple", "test", "data" } },
                    new object[] { "single", new [] { "single", } },
                    new object[] { "stRaNgeCasIng", new [] { "st", "ra", "nge", "cas", "ing" } }
                };
            }
        }

        [Theory]
        [MemberData("FromData")]
        public void ConvertsFromCorrectly(string input, string[] expected)
        {
            CasingContext result = input.FromCamel();

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
                    new object[] { new CasingContext(new[] { "some", "simple", "test", "data" }), "someSimpleTestData" },
                    new object[] { new CasingContext(new[] { "single" }), "Single" },
                    new object[] { new CasingContext(new[] { "st", "ra", "nge", "cas", "ing" }), "stRaNgeCasIng" }
                };
            }
        }

        [Theory]
        [MemberData("ToDat")]
        public void ConvertsToCorrectly(CasingContext input, string expected)
        {
            string result = input.ToCamel();

            Assert.Equal(expected, result);
        }

    }
}
