![Build Status](https://ci.appveyor.com/api/projects/status/github/jackmott/LinqFaster "Build Status")

[<img src="https://jackmott.github.io/images/patreonsmall.png">](https://www.patreon.com/jackmott)

# LinqFaster  

![Logo](https://jackmott.github.io/images/LinqFaster.png "Logo")

A set of extension methods for `arrays[]` and `List<T>` that are faster and allocate less.

LinqFaster now includes all relevant Linq extension methods, and **SIMD** and **parallel** enhanced extension methods are
being worked on now as well.

The base LinqFaster package is now compatible with Unity3D, just define UNITY_CONFIG

## [Beta now available on Nuget](https://www.nuget.org/packages?q=linqfaster)

# Benchmarks

64bit Win 10, 2 Core I7 Mobile

 |             Method | TEST_SIZE |           Mean | Allocated |
 |------------------- |---------- |--------------- |---------- |
 |        OrderByLinq |    100000 | 24,436.0135 us |    1.2 MB |
 |        OrderByFast |    100000 |  5,612.7712 us |  802.1 kB |
 |            MinLinq |    100000 |    548.9181 us |      48 B |
 |            MinFast |    100000 |     69.2122 us |       0 B |
 |        MinFastSIMD |    100000 |     14.5291 us |       0 B |
 |            SumLinq |    100000 |    541.3823 us |      48 B |
 |            SumFast |    100000 |     53.8166 us |       0 B |
 |        SumFastSIMD |    100000 |      9.7636 us |       0 B |
 |SumFastSIMDParallel |    100000 |      3.7074 us |   1.11 kB |


More detailed info and benchmarks available in the **[benchmarks](Benchmarks.md)**  file which
will be continually updated.


# Please Contribute
This is a work in progress, PRs would be appreciated. Lots of easy grunt work to do here to cover all the Linq extension methods. Feel free to contact me I can give guidance if you are not sure what to do or how to use github / git.
We need more tests and I would love input on performance tweaks.

# Features

* **SIMD** enhanced array operations
* :arrow_down: Execution time
* :arrow_down: GC churn
* :arrow_up: Battery life
* :arrow_down: Sever farm costs
* :arrow_down: Co2 output
* :arrow_down: Electricity bill
* :arrow_up: L1 cache hits
* :arrow_up: FPS!

# Use
All LinqFaster extenions methods replicate the Linq names and function signatures, but we
append an "F" to avoid name collisions, so that you can use regular Linq alongside
LinqFaster.  SIMD enhanced functions have an S appended.

```c#
using JM.LinqFaster;
using JM.LinqFaster.SIMD;  // for SIMD

var a = someArray.WhereSelectF(x => x % 2 == 0, x=> x*x);
var b = someList.MinF();
var c = someList.SumF();

var d = someArray.SumS(); //SIMD enhanced Sum
```

# Limitations

These are purely imperative implementations of the same higher order functions that
Linq provides, but unlike Linq they are not lazily evaluated.  This means that when chaining
functions together such as:

```c#

var a = data.Where(predicate).Select(transform).Aggregate(foo);
//or
var b = data.Select(selector).Sum();

```
Linq would not do any work until the calls to `Sum()` or `Aggregate()`, and thus iterate over the collection only once and
allocate very little. LinqFaster used this way would iterate over the collection each time and allocate
much more.  Sometimes the net result will still be faster overall but the better approach is to
use the combined LinqFaster operations such as `SelectWhere`, `WhereSelect`, and `WhereAggregate`.
For example the expressions above would become:

```c#

var a = data.WhereAggregate(predicate,transform,foo);
// and
var b = data.Sum(selector);

```

This gets you the best of both worlds.  The speed of memory locality and no allocations at all.
In short, think about how you are transforming your data. In some cases normal Linq may be the better choice.

While most of the functions strive to provide indentical results to Linq, the OrderBy methods are not a stable sort, while in Linq they are.







