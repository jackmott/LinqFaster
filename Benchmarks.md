``` ini

BenchmarkDotNet=v0.10.3.0, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-6600U CPU 2.60GHz, ProcessorCount=4
Frequency=2742188 Hz, Resolution=364.6723 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 64bit RyuJIT-v4.6.1637.0
  DefaultJob : Clr 4.0.30319.42000, 64bit RyuJIT-v4.6.1637.0


```
 |           Method | TEST_SIZE |                Mean |            StdDev |
 |----------------- |---------- |-------------------- |------------------ |
 | **SelectLinqFaster** |       **100** |       **1,578.2046 ns** |        **33.6516 ns** |
 |       SelectLinq |       100 |       1,282.7017 ns |        28.7260 ns |
 |  WhereLinqFaster |       100 |       1,297.8546 ns |        25.1934 ns |
 |        WhereLinq |       100 |         957.4197 ns |        45.3095 ns |
 | **SelectLinqFaster** |  **10000000** | **176,940,320.3881 ns** | **4,213,808.7948 ns** |
 |       SelectLinq |  10000000 | 139,707,733.6905 ns |   975,855.3571 ns |
 |  WhereLinqFaster |  10000000 | 182,708,851.6589 ns |   930,856.7298 ns |
 |        WhereLinq |  10000000 | 149,473,422.3183 ns | 1,160,919.4309 ns |
