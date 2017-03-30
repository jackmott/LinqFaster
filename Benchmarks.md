``` ini

BenchmarkDotNet=v0.10.3.0, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-6600U CPU 2.60GHz, ProcessorCount=4
Frequency=2742188 Hz, Resolution=364.6723 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0


```
 |                 Method | TEST_SIZE |           Mean |      StdDev |         Median | Allocated |
 |----------------------- |---------- |--------------- |------------ |--------------- |---------- |
 |            OrderByFast |    100000 |  7,316.2296 us | 240.5493 us |  7,322.0955 us | 802.08 kB |
 |            OrderByLinq |    100000 | 26,590.7857 us | 319.3442 us | 26,548.6007 us |    1.2 MB |
 |                MinFast |    100000 |    165.9678 us |   1.9937 us |    166.8185 us |       0 B |
 |                MinLinq |    100000 |    502.8024 us |  11.0650 us |    498.1669 us |      32 B |
 |                SumFast |    100000 |     46.2954 us |   2.4506 us |     45.8065 us |       0 B |
 |                SumLinq |    100000 |    466.7067 us |  11.7155 us |    473.1926 us |      32 B |
 |      SumWithSelectFast |    100000 |    538.7280 us |  12.5925 us |    530.0984 us |       0 B |
 |      SumWithSelectLinq |    100000 |  1,192.2225 us |  26.9725 us |  1,177.0654 us |      64 B |
 | WhereSelectAverageFast |    100000 |  1,132.9057 us |   1.1447 us |  1,132.8004 us |       0 B |
 | WhereSelectAverageLinq |    100000 |  1,459.9109 us |   4.1934 us |  1,459.5469 us |      96 B |
