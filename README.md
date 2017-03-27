# LinqFaster
A set of extension methods for array and `List<T>` that are faster and allocate less. This eventually will cover all the Linq extension methods
that are appropriate, and then some. I plan to add SIMD versions where appropriate, in place array Select, minBy and maxBy etc.

# Features

* Goes faster
* Allocates less
* Saves Battery life
* Reduces server farm costs
* Reduces co2 output
* Reduces electricity bill

# Use

```
someArray.Where(x => x % 2  ==).Select(x => x*x)
someList.Min();
```

Just like Linq! But it will go faster!



