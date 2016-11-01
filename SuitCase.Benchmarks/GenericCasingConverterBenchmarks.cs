using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuitCase.Benchmarks
{
    public class GenericCasingConverterBenchmarks
    {

        public GenericCasingConverter Converter { get; set; }

        public GenericCasingConverterBenchmarks()
        {
            Converter = new GenericCasingConverter(new CasingSyntax()
            {
                TerminationType = TermTermination.Uppercase,
                IncludeTerminator = true
            });
        }

        [Benchmark]
        public CasingContext FromCase()
        {
            return Converter.FromCase("SomeSimpleTestData");
        }

    }
}
