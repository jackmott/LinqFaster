![Build Status](https://ci.appveyor.com/api/projects/status/github/jackmott/LinqFaster "Build Status")

[<img src="https://liberapay.com/assets/widgets/donate.svg">](https://liberapay.com/jackmott/donate)

# LinqFaster
A set of extension methods for array and `List<T>` that are faster and allocate less, making them more appropriate for mobile, big data, science, gamedev, and everything because wasting cpu cycles is a sin, and hateful.

This eventually will cover all the Linq extension methods
that are appropriate, and then some. I plan to add SIMD versions where appropriate, in place array Select, minBy and maxBy etc.

# [Benchmarks](Benchmarks.md)

# Please Contribute
This is a work in progress, PRs would be appreciated. Lots of easy grunt work to do here to cover all the Linq extension methods. Feel free to contact me I can give guidance if you are not sure what to do or how to use github / git.
We need tests and I would love input on performance tweaks.

# Features

* :arrow_down: Execution time
* :arrow_down: GC churn
* :arrow_up: Battery life
* :arrow_down: Sever farm costs
* :arrow_down: Co2 output
* :arrow_down: Electricity bill
* :arrow_up: L1 cache hits
* :arrow_up: FPS!

# Use

```c#
someArray.WhereSelect(x => x % 2 == 0, x=> x*x);
someList.Min();
```

# Limitations

These are purely imperative implementations of the same higher order functions that
Linq provides, but unlike Linq they are not lazily evaluated.  This means that when chaining
functions together such as:

```c#

data.Where(predicate).Select(transform).Aggregate(foo);
//or
data.Select(selector).Sum();

```
Linq would not do any work until the calls to `Sum()` or `Aggregate()`, and thus iterate over the collection only once and
allocate very little. LinqFaster used this way would iterate over the collection each time and allocate
much more.  Sometimes the net result will still be faster overall but the better approach is to
use the combined LinqFaster operations such as `SelectWhere`, `WhereSelect`, and `WhereAggregate`.
For example the expressions above would become:

```c#

data.WhereAggregate(predicate,transform,foo);
// and
data.Sum(selector);

```

This gets you the best of both worlds.  The speed of memory locality and no allocations at all.
In short, think about how you are transforming your data. In some cases normal Linq may be the better choice.







