
``` ini

BenchmarkDotNet=v0.10.3.0, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-6600U CPU 2.60GHz, ProcessorCount=4
Frequency=2742188 Hz, Resolution=364.6723 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 64bit RyuJIT-v4.6.1637.0
  DefaultJob : Clr 4.0.30319.42000, 64bit RyuJIT-v4.6.1637.0


```
 |           Method | TEST_SIZE |                Mean |            StdDev |
 |----------------- |---------- |-------------------- |------------------ |
 | **SelectLinqFaster** |       **100** |         **386.2112 ns** |        **20.0791 ns** |
 |       SelectLinq |       100 |         798.2044 ns |         7.8740 ns |
 |  WhereLinqFaster |       100 |         622.4990 ns |         8.9175 ns |
 |        WhereLinq |       100 |         628.4474 ns |        12.1479 ns |
 | **SelectLinqFaster** |  **10000000** |  **46,378,637.2632 ns** |   **414,892.2381 ns** |
 |       SelectLinq |  10000000 |  76,301,022.3648 ns | 2,906,661.0960 ns |
 |  WhereLinqFaster |  10000000 | 114,265,776.6960 ns |   689,636.2432 ns |
 |        WhereLinq |  10000000 | 110,151,638.0351 ns |   876,110.1250 ns |
