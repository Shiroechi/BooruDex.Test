using System;
using System.Net.Http;
using System.Threading.Tasks;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Mathematics;
using BenchmarkDotNet.Order;

using BooruDex.Booru.Client;
using BooruDex.Models;

using BooruSharp.Booru;

namespace BooruDex.Test.Benchmark
{
	[MemoryDiagnoser]
	[MinColumn, MaxColumn]
	[Orderer(SummaryOrderPolicy.FastestToSlowest)]
	[RankColumn(NumeralSystem.Arabic)]
	[MediumRunJob]
	public class BooruBenchmark
	{
		public Booru.Booru booru;
		public HttpClient HttpClient { set; get; }

		public BooruBenchmark()
		{
			//this.booru = new Yandere();
			this.HttpClient = new HttpClient();
			//this.HttpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.169 Safari/537.36");
		}

		//[Params(123)]
		//public uint poolId;

		[Benchmark]
		public async Task<Post[]> DanbooruBooruDex()
		{
			try
			{
				var booru = new Booru.Client.DanbooruDonmai(this.HttpClient);
				return await booru.GetRandomPostAsync(10);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return null;
			}
		}

		[Benchmark]
		public async Task<BooruSharp.Search.Post.SearchResult[]> DanbooruBooruSharp()
		{
			try
			{
				var booru = new BooruSharp.Booru.DanbooruDonmai();
				booru.HttpClient = this.HttpClient;
				return await booru.GetRandomPostsAsync(10, null);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return null;
			}
		}

		[Benchmark]
		public async Task<Post[]> YandereBooruDex()
		{
			try
			{
				var booru = new Booru.Client.Yandere(this.HttpClient);
				return await booru.GetRandomPostAsync(10);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return null;
			}
		}

		[Benchmark]
		public async Task<BooruSharp.Search.Post.SearchResult[]> YandereBooruSharp()
		{
			try
			{
				var booru = new BooruSharp.Booru.Yandere();
				booru.HttpClient = this.HttpClient;
				return await booru.GetRandomPostsAsync(10, null);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return null;
			}
		}
	}
}
