# BooruDex.Test
Bencmark result for BooruDex

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1198 (1909/November2018Update/19H2)
AMD FX-8800P Radeon R7, 12 Compute Cores 4C+8G, 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]    : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  MediumRun : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|             Method |     Mean |    Error |   StdDev |      Min |      Max | Rank | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------- |---------:|---------:|---------:|---------:|---------:|-----:|------:|------:|------:|----------:|
| DanbooruBooruDexV1 | 410.5 ms | 17.26 ms | 23.62 ms | 380.5 ms | 465.0 ms |    1 |     - |     - |     - |  253.5 KB |
| DanbooruBooruSharp | 418.4 ms | 25.73 ms | 36.91 ms | 370.9 ms | 532.5 ms |    1 |     - |     - |     - | 344.31 KB |
| DanbooruBooruDexV2 | 438.7 ms | 56.41 ms | 80.90 ms | 383.5 ms | 720.6 ms |    1 |     - |     - |     - |  68.76 KB |

**Note**
*Speed or perfomace may not accurate because internet connection or server response*

All library retrieve 10 random post from [danbooru](https://danbooru.donmai.us/).

[BooruDexV1](https://www.nuget.org/packages/BooruDex/1.0.0) was more effecient in handling memory(RAM) usage than [BooruSharp](https://github.com/Xwilarg/BooruSharp). 
Both library use [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) for processing JSON response. 

But `BooruDexV2` is more effecient after migrating from [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) to [System.Text.Json](https://www.nuget.org/packages/System.Text.Json). The memory(RAM) usage is more reduced. 
As you know in [BooruDexV1](https://www.nuget.org/packages/BooruDex/1.0.0) has error for parsing data from danbooru, it was fixed in `BooruDexV2`.
