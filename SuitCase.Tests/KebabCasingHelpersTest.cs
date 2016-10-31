using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SuitCase.Tests
{
    public class KebabCasingHelpersTest
    {

        public static IEnumerable<object[]> FromData
        {
            get
            {
                return new List<object[]>
                {
                    new object[] { "some-simple-test-data", new [] { "some", "simple", "test", "data" } },
                    new object[] { "single", new [] { "single", } },
                    new object[] { "st-Ra-Nge-Cas-Ing", new [] { "st", "ra", "nge", "cas", "ing" } }
                };
            }
        }

        [Theory]
        [MemberData("FromData")]
        public void ConvertsFromCorrectly(string input, string[] expected)
        {
            CasingContext result = input.FromKebabCase();

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
                    new object[] { new CasingContext(new[] { "some", "simple", "test", "data" }), "some-simple-test-data" },
                    new object[] { new CasingContext(new[] { "single" }), "single" },
                    new object[] { new CasingContext(new[] { "st", "ra", "nge", "cas", "ing" }), "st-ra-nge-cas-ing" }
                };
            }
        }

        [Theory]
        [MemberData("ToData")]
        public void ConvertsToCorrectly(CasingContext input, string expected)
        {
            string result = input.ToKebabCase();

            Assert.Equal(expected, result);
        }

    }
}
