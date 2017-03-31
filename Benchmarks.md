``` ini

BenchmarkDotNet=v0.10.3.0, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-6600U CPU 2.60GHz, ProcessorCount=4
Frequency=2742188 Hz, Resolution=364.6723 ns, Timer=TSC
  [Host]    : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0
  RyuJitX64 : Clr 4.0.30319.42000, 64bit RyuJIT-v4.6.1637.0

Job=RyuJitX64  Jit=RyuJit  Platform=X64  

```
 |             Method | TEST_SIZE |           Mean |      StdErr |        StdDev |         Median |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
 |------------------- |---------- |--------------- |------------ |-------------- |--------------- |--------- |--------- |--------- |---------- |
 |        OrderByLinq |    100000 | 24,436.0135 us | 278.0583 us | 1,333.5208 us | 23,928.5641 us |        - |        - |        - |    1.2 MB |
 |        OrderByFast |    100000 |  5,612.7712 us |  32.0852 us |   124.2656 us |  5,538.3960 us |  76.0417 |  76.0417 |  76.0417 |  802.1 kB |
 |            MinLinq |    100000 |    548.9181 us |   0.4265 us |     1.4144 us |    548.6541 us |        - |        - |        - |      48 B |
 |            MinFast |    100000 |     69.2122 us |   0.6784 us |     3.1087 us |     71.0877 us |        - |        - |        - |       0 B |
 |            SumLinq |    100000 |    541.3823 us |   3.1408 us |    12.1644 us |    549.9876 us |        - |        - |        - |      48 B |
 |            SumFast |    100000 |     53.8166 us |   0.1246 us |     0.4493 us |     54.0183 us |        - |        - |        - |       0 B |
 |        SumFastSIMD |    100000 |      9.7636 us |   0.0205 us |     0.0711 us |      9.7664 us |        - |        - |        - |       0 B |
 |        AverageLinq |    100000 |    597.9478 us |   3.6422 us |    14.1064 us |    589.3728 us |        - |        - |        - |      48 B |
 |        AverageFast |    100000 |     75.1587 us |   0.7228 us |     2.7043 us |     75.3123 us |        - |        - |        - |       0 B |
 |    AverageFastSIMD |    100000 |      9.4883 us |   0.0541 us |     0.2097 us |      9.3508 us |        - |        - |        - |       0 B |
 |  SumWithSelectLinq |    100000 |    687.0656 us |   0.3313 us |     1.2398 us |    686.9569 us |        - |        - |        - |      64 B |
 |  SumWithSelectFast |    100000 |    224.2140 us |   1.0869 us |     4.2097 us |    225.7953 us |        - |        - |        - |       0 B |
 | WhereAggregateLinq |    100000 |  1,131.5610 us |   6.4923 us |    25.1445 us |  1,148.0422 us |        - |        - |        - |     128 B |
 | WhereAggregateFast |    100000 |    718.0344 us |   3.6760 us |    14.2372 us |    725.7318 us |        - |        - |        - |      80 B |
 |         SelectFast |    100000 |    428.5854 us |   0.4835 us |     1.7432 us |    428.5549 us |  91.1458 |  91.1458 |  91.1458 | 400.02 kB |
 |     SelectFastSIMD |    100000 |    206.8289 us |   0.8936 us |     3.4610 us |    206.4088 us | 102.8646 | 102.8646 | 102.8646 | 400.02 kB |
