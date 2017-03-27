``` ini

BenchmarkDotNet=v0.10.3.0, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-6600U CPU 2.60GHz, ProcessorCount=4
Frequency=2742188 Hz, Resolution=364.6723 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 64bit RyuJIT-v4.6.1637.0
  DefaultJob : Clr 4.0.30319.42000, 64bit RyuJIT-v4.6.1637.0


```
 |           Method | TEST_SIZE |               Mean |          StdErr |          StdDev |             Median |
 |----------------- |---------- |------------------- |---------------- |---------------- |------------------- |
 | **SelectLinqFaster** |       **100** |        **304.5574 ns** |       **1.7626 ns** |       **6.8266 ns** |        **302.9222 ns** |
 |       SelectLinq |       100 |         22.7866 ns |       0.2924 ns |       1.8724 ns |         21.8901 ns |
 | **SelectLinqFaster** |    **100000** |    **303,323.7046 ns** |     **792.4641 ns** |   **2,857.2698 ns** |    **303,824.9921 ns** |
 |       SelectLinq |    100000 |         21.4333 ns |       0.1174 ns |       0.4394 ns |         21.3414 ns |
 | **SelectLinqFaster** |  **10000000** | **38,630,664.7239 ns** | **104,316.9793 ns** | **390,318.3963 ns** | **38,699,477.0841 ns** |
 |       SelectLinq |  10000000 |         21.4145 ns |       0.1153 ns |       0.4314 ns |         21.5467 ns |
