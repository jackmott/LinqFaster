
``` ini

BenchmarkDotNet=v0.10.3.0, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-6600U CPU 2.60GHz, ProcessorCount=4
Frequency=2742188 Hz, Resolution=364.6723 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 64bit RyuJIT-v4.6.1637.0
  DefaultJob : Clr 4.0.30319.42000, 64bit RyuJIT-v4.6.1637.0


```
 |           Method | TEST_SIZE |                Mean |            StdDev |
 |----------------- |---------- |-------------------- |------------------ |
 | **SelectLinqFaster** |       **100** |         **304.8399 ns** |         **5.3932 ns** |
 |       SelectLinq |       100 |       1,319.8975 ns |        30.0837 ns |
 | **SelectLinqFaster** |    **100000** |     **307,316.8480 ns** |     **3,403.7513 ns** |
 |       SelectLinq |    100000 |   1,524,372.9414 ns |    39,966.7960 ns |
 | **SelectLinqFaster** |  **10000000** |  **38,567,270.0808 ns** |   **437,889.3283 ns** |
 |       SelectLinq |  10000000 | 156,447,374.3230 ns | 3,022,294.6038 ns |
