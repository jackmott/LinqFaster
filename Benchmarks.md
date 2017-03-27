
``` ini

BenchmarkDotNet=v0.10.3.0, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-6600U CPU 2.60GHz, ProcessorCount=4
Frequency=2742188 Hz, Resolution=364.6723 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 64bit RyuJIT-v4.6.1637.0
  DefaultJob : Clr 4.0.30319.42000, 64bit RyuJIT-v4.6.1637.0


```
 |                       Method | TEST_SIZE |                Mean |          StdErr |          StdDev |
 |----------------------------- |---------- |-------------------- |---------------- |---------------- |
 | **WhereSelectAverageLinqFaster** |       **100** |         **745.5495 ns** |       **3.3448 ns** |      **12.9545 ns** |
 | WhereSelectAverageSelectLinq |       100 |         771.8319 ns |       8.8280 ns |      34.1906 ns |
 | **WhereSelectAverageLinqFaster** |  **10000000** | **137,018,212.2165 ns** | **163,358.1449 ns** | **611,230.2096 ns** |
 | WhereSelectAverageSelectLinq |  10000000 | 119,821,662.8625 ns | 182,423.2400 ns | 706,522.1705 ns |
