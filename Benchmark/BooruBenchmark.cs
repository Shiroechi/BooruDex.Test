using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Mathematics;
using BenchmarkDotNet.Order;

using BooruDex.Booru.Client;
using BooruDex.Models;

namespace BooruDex.Test.Benchmark
{
	[MemoryDiagnoser]
	[MinColumn, MaxColumn]
	[Orderer(SummaryOrderPolicy.FastestToSlowest)]
	[RankColumn(NumeralSystem.Arabic)]
	[MediumRunJob]
	public class BooruBenchmark
	{
		public HttpClient HttpClient { set; get; }

		public BooruBenchmark()
		{
			//this.booru = new Yandere();
			this.HttpClient = new HttpClient(
				//handler: new HttpClientHandler
				//{
				//	ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
				//}, true
				);
			ServicePointManager.SecurityProtocol =
				SecurityProtocolType.Tls12
				| SecurityProtocolType.Tls11
				| SecurityProtocolType.Tls;
			//this.HttpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.169 Safari/537.36");
		}

		//[Params(123)]
		public uint poolId = 123;

		[Benchmark(Baseline = true)]
		public async Task<Post[]> BooruDex()
		{
			try
			{
				var booru = new DanbooruDonmai()
				{
					HttpClient = this.HttpClient
				};
				return await booru.PostListAsync(10, new string[] { "ass" });
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return null;
			}
		}

		[Benchmark]
		public async Task<BooruSharp.Search.Post.SearchResult[]> BooruSharp()
		{
			try
			{
				var booru = new BooruSharp.Booru.DanbooruDonmai
				{
					HttpClient = this.HttpClient
				};
				return await booru.GetLastPostsAsync(10, "ass");
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return null;
			}
		}

	}

}
