using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuitCase.Benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var switcher = new BenchmarkSwitcher(new[] {
                typeof(GenericCasingConverterBenchmarks)
            });
            switcher.Run(args);
        }
    }
}
