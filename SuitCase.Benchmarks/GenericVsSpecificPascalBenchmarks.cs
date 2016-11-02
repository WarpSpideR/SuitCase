using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuitCase.Benchmarks
{
    public class GenericVsSpecificPascalBenchmarks
    {

        public GenericCasingConverter Generic { get; set; }

        public CasingSyntax Syntax { get; set; }

        public CasingContext Context { get; set; }

        public GenericVsSpecificPascalBenchmarks()
        {
            Syntax = new CasingSyntax()
            {
                TerminationType = TermTermination.Uppercase,
                IncludeTerminator = true
            };
            Generic = new GenericCasingConverter(Syntax);
            Context = new CasingContext(new[] { "some", "simple", "test", "data" });
        }

        [Benchmark]
        public CasingContext GenericFromCase()
        {
            return Generic.FromCase("SomeSimpleTestData");
        }

        [Benchmark]
        public CasingContext SpecificFromCase()
        {
            return "SomeSimpleTestData".FromPascal();
        }

        [Benchmark]
        public string GenericToCase()
        {
            return Generic.ToCase(Context, Syntax);
        }

        [Benchmark]
        public string SpecificToCase()
        {
            return Context.ToPascal();
        }

    }
}
