``` ini

BenchmarkDotNet=v0.10.3.0, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-6600U CPU 2.60GHz, ProcessorCount=4
Frequency=2742188 Hz, Resolution=364.6723 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 64bit RyuJIT-v4.6.1637.0
  DefaultJob : Clr 4.0.30319.42000, 64bit RyuJIT-v4.6.1637.0


```
 |                 Method | TEST_SIZE |       Mean |    StdErr |    StdDev |
 |----------------------- |---------- |----------- |---------- |---------- |
 |      ListSumLinqFaster |  10000000 | 10.8284 ms | 0.0586 ms | 0.2270 ms |
 |            ListSumLinq |  10000000 | 70.9016 ms | 0.7103 ms | 3.0137 ms |
 |  ListAverageLinqFaster |  10000000 | 13.5903 ms | 0.0211 ms | 0.0819 ms |
 |        ListAverageLinq |  10000000 | 71.9013 ms | 0.0853 ms | 0.3193 ms |
 |     ArraySumLinqFaster |  10000000 |  5.9221 ms | 0.0113 ms | 0.0407 ms |
 |           ArraySumLinq |  10000000 | 53.8434 ms | 0.2193 ms | 0.8492 ms |
 | ArrayAverageLinqFaster |  10000000 |  8.4227 ms | 0.0111 ms | 0.0416 ms |
 |       ArrayAverageLinq |  10000000 | 62.3885 ms | 0.1405 ms | 0.5440 ms |
