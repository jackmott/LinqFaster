# LinqFaster
A set of extension methods for array and `List<T>` that are faster and allocate less, making them more appropriate for mobile, big data, science, gamedev, and everything because wasting cpu cycles is a sin, and hateful.

This eventually will cover all the Linq extension methods
that are appropriate, and then some. I plan to add SIMD versions where appropriate, in place array Select, minBy and maxBy etc.

# Features

* :arrow_down: Execution time
* :arrow_down: GC churn
* :up_arrow: Battery life
* :arrow_down: Sever farm costs
* :arrow_down: Co2 output
* :arrow_down: Electricity bill
* :arrow_up: L1 cache hits
* :arrow_up: FPS!

# Use

```
someArray.Where(x => x % 2  ==).Select(x => x*x)
someList.Min();
```

Just like Linq! But it will go faster!



