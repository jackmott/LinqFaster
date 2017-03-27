``` ini

BenchmarkDotNet=v0.10.3.0, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-6600U CPU 2.60GHz, ProcessorCount=4
Frequency=2742188 Hz, Resolution=364.6723 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 64bit RyuJIT-v4.6.1637.0
  DefaultJob : Clr 4.0.30319.42000, 64bit RyuJIT-v4.6.1637.0


```
 |           Method | TEST_SIZE |       Mean |    StdErr |    StdDev |
 |----------------- |---------- |----------- |---------- |---------- |
 | **SelectLinqFaster** |       **100** |  **5.8273 ns** | **0.0413 ns** | **0.1601 ns** |
 |       SelectLinq |       100 | 21.7893 ns | 0.2633 ns | 1.3683 ns |
 | **SelectLinqFaster** |    **100000** |  **5.7576 ns** | **0.0713 ns** | **0.2761 ns** |
 |       SelectLinq |    100000 | 21.4218 ns | 0.0651 ns | 0.2348 ns |
 | **SelectLinqFaster** |  **10000000** |  **5.6025 ns** | **0.0476 ns** | **0.1648 ns** |
 |       SelectLinq |  10000000 | 20.7460 ns | 0.0881 ns | 0.3297 ns |
