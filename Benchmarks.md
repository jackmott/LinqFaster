``` ini

BenchmarkDotNet=v0.10.3.0, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-6600U CPU 2.60GHz, ProcessorCount=4
Frequency=2742188 Hz, Resolution=364.6723 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 64bit RyuJIT-v4.6.1637.0
  DefaultJob : Clr 4.0.30319.42000, 64bit RyuJIT-v4.6.1637.0


```
 |                   Method | TEST_SIZE |       Mean |    StdDev |
 |------------------------- |---------- |----------- |---------- |
 |        ListSumLinqFaster |  10000000 | 10.5551 ms | 0.2464 ms |
 |              ListSumLinq |  10000000 | 68.4477 ms | 0.9946 ms |
 |    ListAverageLinqFaster |  10000000 | 14.1943 ms | 0.4421 ms |
 |          ListAverageLinq |  10000000 | 71.5661 ms | 1.0920 ms |
 |  ListSelectSumLinqFaster |  10000000 | 68.4644 ms | 0.3579 ms |
 |        ListSelectSumLinq |  10000000 | 98.4447 ms | 1.1807 ms |
 |       ArraySumLinqFaster |  10000000 |  6.0303 ms | 0.1006 ms |
 |             ArraySumLinq |  10000000 | 53.8206 ms | 1.9514 ms |
 |   ArrayAverageLinqFaster |  10000000 |  8.2880 ms | 0.1391 ms |
 |         ArrayAverageLinq |  10000000 | 61.9419 ms | 1.1031 ms |
 | ArraySelectSumLinqFaster |  10000000 | 38.2473 ms | 0.5487 ms |
 |       ArraySelectSumLinq |  10000000 | 69.1699 ms | 2.1079 ms |
 | ArrayWhereSumLinqFaster |  10000000 |  89.7150 ms | 1.0154 ms |
 |       ArrayWhereSumLinq |  10000000 | 104.4176 ms | 1.2041 ms |
 |  ListWhereSumLinqFaster |  10000000 | 119.5052 ms | 0.7478 ms |
 |        ListWhereSumLinq |  10000000 | 131.6459 ms | 1.5655 ms |
 | ArrayMinLinqFaster |  10000000 |  6.7343 ms | 0.1657 ms |
 |       ArrayMinLinq |  10000000 | 55.7514 ms | 0.7147 ms |
 |  ListMinLinqFaster |  10000000 | 10.3906 ms | 0.4000 ms |
 |        ListMinLinq |  10000000 | 72.4025 ms | 1.0256 ms |
