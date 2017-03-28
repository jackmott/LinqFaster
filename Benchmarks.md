``` ini

BenchmarkDotNet=v0.10.3.0, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-6600U CPU 2.60GHz, ProcessorCount=4
Frequency=2742188 Hz, Resolution=364.6723 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 64bit RyuJIT-v4.6.1637.0
  DefaultJob : Clr 4.0.30319.42000, 64bit RyuJIT-v4.6.1637.0


```
 |                       Method | TEST_SIZE |        Mean |    StdErr |    StdDev |      Median |       Gen 0 |     Gen 1 |     Gen 2 | Allocated |
 |----------------------------- |---------- |------------ |---------- |---------- |------------ |------------ |---------- |---------- |---------- |
 |            ListSumLinqFaster |   5000000 |   4.8353 ms | 0.0086 ms | 0.0312 ms |   4.8351 ms |           - |         - |         - |       0 B |
 |                  ListSumLinq |   5000000 |  31.5585 ms | 0.0462 ms | 0.1788 ms |  31.5035 ms |           - |         - |         - |     512 B |
 |        ListAverageLinqFaster |   5000000 |   6.2666 ms | 0.0754 ms | 0.3017 ms |   6.1034 ms |           - |         - |         - |       0 B |
 |              ListAverageLinq |   5000000 |  33.1415 ms | 0.0459 ms | 0.1654 ms |  33.1072 ms |           - |         - |         - |     512 B |
 |      ListSelectSumLinqFaster |   5000000 |  32.4783 ms | 0.3130 ms | 1.3644 ms |  31.7335 ms |           - |         - |         - |     20 MB |
 |            ListSelectSumLinq |   5000000 |  43.8589 ms | 0.0435 ms | 0.1506 ms |  43.8637 ms |           - |         - |         - |     512 B |
 |           ArraySumLinqFaster |   5000000 |   2.6258 ms | 0.0067 ms | 0.0250 ms |   2.6198 ms |           - |         - |         - |       0 B |
 |                 ArraySumLinq |   5000000 |  24.8480 ms | 0.2462 ms | 1.3708 ms |  24.1799 ms |           - |         - |         - |     512 B |
 |       ArrayAverageLinqFaster |   5000000 |   3.6593 ms | 0.0081 ms | 0.0302 ms |   3.6632 ms |           - |         - |         - |       0 B |
 |             ArrayAverageLinq |   5000000 |  28.6360 ms | 0.0587 ms | 0.2196 ms |  28.6161 ms |           - |         - |         - |     512 B |
 |     ArraySelectSumLinqFaster |   5000000 |  19.4265 ms | 0.1598 ms | 0.5978 ms |  19.3629 ms |           - |         - |         - |     20 MB |
 |           ArraySelectSumLinq |   5000000 |  30.1052 ms | 0.0369 ms | 0.1329 ms |  30.0671 ms |           - |         - |         - |     512 B |
 |      ArrayWhereSumLinqFaster |   5000000 |  42.0112 ms | 0.2304 ms | 0.8924 ms |  42.4411 ms |           - |         - |         - |     30 MB |
 |            ArrayWhereSumLinq |   5000000 |  47.4958 ms | 0.0305 ms | 0.1141 ms |  47.4758 ms |           - |         - |         - |     512 B |
 |       ListWhereSumLinqFaster |   5000000 |  58.3609 ms | 0.0798 ms | 0.2985 ms |  58.3412 ms |     75.0000 |   12.5000 |   12.5000 |  33.56 MB |
 |             ListWhereSumLinq |   5000000 |  59.6467 ms | 0.0646 ms | 0.2331 ms |  59.5954 ms |           - |         - |         - |     512 B |
 |           ArrayMinLinqFaster |   5000000 |   3.2380 ms | 0.0319 ms | 0.1497 ms |   3.1680 ms |           - |         - |         - |       0 B |
 |                 ArrayMinLinq |   5000000 |  25.6210 ms | 0.0265 ms | 0.0955 ms |  25.6497 ms |           - |         - |         - |     512 B |
 |            ListMinLinqFaster |   5000000 |   4.6294 ms | 0.0068 ms | 0.0245 ms |   4.6362 ms |           - |         - |         - |       0 B |
 |                  ListMinLinq |   5000000 |  33.1241 ms | 0.0327 ms | 0.1180 ms |  33.1031 ms |           - |         - |         - |     512 B |
 | ArraySelectManySumLinqFaster |   5000000 | 282.6680 ms | 1.0823 ms | 4.1918 ms | 282.8662 ms | 115516.6667 | 1079.1667 | 1079.1667 | 640.01 MB |
 |       ArraySelectManySumLinq |   5000000 | 384.6252 ms | 0.4837 ms | 1.8098 ms | 383.8514 ms | 190070.8333 |         - |         - | 400.01 MB |
 |  ListSelectManySumLinqFaster |   5000000 |  83.1875 ms | 0.4418 ms | 1.7111 ms |  82.7278 ms | 209468.7500 |         - |         - | 460.01 MB |
 |        ListSelectManySumLinq |   5000000 | 186.3895 ms | 1.0637 ms | 3.9799 ms | 184.2727 ms | 304491.6667 |         - |         - | 640.02 MB |
 |  ArrayRangeAverageLinqFaster |   5000000 |  12.3611 ms | 0.0823 ms | 0.3078 ms |  12.3346 ms |           - |         - |         - |     20 MB |
 |             RangeAverageLinq |   5000000 |  24.0676 ms | 0.0058 ms | 0.0192 ms |  24.0692 ms |           - |         - |         - |     512 B |
 |   ListRangeAverageLinqFaster |   5000000 |  24.2170 ms | 0.1059 ms | 0.4102 ms |  24.2855 ms |           - |         - |         - |     20 MB |
 |     ArrayAggregateLinqFaster |   5000000 |  10.6317 ms | 0.0242 ms | 0.0905 ms |  10.6152 ms |           - |         - |         - |       0 B |
 |           ArrayAggregateLinq |   5000000 |  37.6655 ms | 0.0299 ms | 0.1080 ms |  37.6928 ms |           - |         - |         - |     512 B |
 |      ListAggregateLinqFaster |   5000000 |  12.2389 ms | 0.0188 ms | 0.0652 ms |  12.2636 ms |           - |         - |         - |       0 B |
 |            ListAggregateLinq |   5000000 |  41.4862 ms | 0.0290 ms | 0.1086 ms |  41.4722 ms |           - |         - |         - |     512 B |
