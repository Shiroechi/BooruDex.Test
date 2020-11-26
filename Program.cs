using System;

using BenchmarkDotNet.Running;

using BooruDex.Test.Benchmark;

namespace BooruDex.Test
{
	class Program
	{
		static async System.Threading.Tasks.Task Main(string[] args)
		{
			try
			{
				var summary = BenchmarkRunner.Run<BooruBenchmark>();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				Console.WriteLine(e.Message);
			}
		}
	}
}
