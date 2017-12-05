![Build Status](https://ci.appveyor.com/api/projects/status/github/jackmott/LinqFaster "Build Status")

[<img src="https://jackmott.github.io/images/patreonsmall.png">](https://www.patreon.com/jackmott)

# LinqFaster  

![Logo](https://jackmott.github.io/images/LinqFaster.png "Logo")

A set of Linq-Like extension methods for `arrays[]` and `List<T>` that are faster and allocate less.  LinqFaster is designed
to work well alongside Linq, rather than replace it completely. Extension method names mirror Linq names with an extra character, e.g. Select**F**.  If you have code that is often doing small Linq operations and immediatelly calling `ToArray()` or `ToList()`, or you are often using `Min`,`Max`,`Sum`,`Average`,or `Aggregate`, LinqFaster may provide massive cpu and memory usage reductions. See the documentation section below for more details.

LinqFaster now includes all relevant Linq extension methods, and many **SIMD** and **parallel** enhanced extension methods are available as well in separate projects and nuget packages.  The projects have no depdencies on each other so you can pick and choose at will.

The base LinqFaster project is now compatible with Unity3D

## [Beta now available on Nuget](https://www.nuget.org/packages?q=linqfaster)

# Sample Benchmarks

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

# Documentation

* [LinqFaster](#linqfaster-1)
* [LinqFaster.SIMD](#linqfastersimd)
* [LinqFaster.Parallel](#linqfasterparallel)
* [LinqFaster.SIMD.Parallel](#linqfastersimdparallel)
* [Limitations](#limitations)

As well, all functions are properly documented so as to be explorable via intellisense.

### LinqFaster
```c#
	using JM.LinqFaster;
	
	
	//Create an array of ints with values -500 to 500
	var myArray = LinqFaster.RangeArrayF(-500, 500);
	//Create a List<T> with 1000 elements all set to 5.0
	var myList = LinqFaster.RepeatListF(5.0, 1000);

	//Compute sum, average, max,min
	var sum = myArray.SumF();
	var average = myArray.AverageF();
	var min = myArray.MinF();
	var max = myArray.MaxF();

	//As above but on a transformation
	var sum2 = myArray.SumF(x => x*x);
	var average2 = myArray.AverageF(x => x*x);
	var min2 = myArray.MinF(x => x*x);
	var max2 = myArray.MaxF(x => x*x);

	//Do a where and a select or select and where in a single pass
	var newArray = myArray.WhereSelectF(x => x % 2 == 0,x=>x*x);
	var newArray2 = myArray.SelectWhereF(x => x * x,x => x % 2 == 0);

	//Compute the sum of only the even values in a single pass
	var filteredSum = myArray.WhereAggregateF(x => x % 2 == 0, (acc, x) => acc + x);

	//New in-place methods are provided where appropriate
	myArray.SelectInPlaceF(x => x * x);
	myArray.ReverseInPlaceF();
```

### LinqFaster.SIMD

See MSDN [documentation](https://msdn.microsoft.com/en-us/library/dn858385(v=vs.111).aspx) on System.Numerics.Vectors
for more detail on SIMD in C#.

```c#
using JM.LinqFaster.SIMD;

// SIMD extension methods are only available for arrays
// SIMD functions all have an S at the end, for clarity
// and to avoid naming collisions.

var myArray = LinqFaster.RangeS(-500, 500);

// Some operations work identically to their scalar
// counterparts,but faster, as long as the machine has 
// SIMD hardware.

var sum = myArray.SumS();
bool b = myArray.ContainsS(5);
var max = myArray.MaxS();

// Floating point math is not commutative, so the results
// of operations such as Sum and Average may differ slightly.
// Accuracy is usually better.

Console.WriteLine(myFloats.SumS() == myFloats.SumF()); // --> False!

// When using selectors, you must provide one that operates on
// Vector<T>. Optionally, you may provide a second selector
// that operates on T to handle elements that are left over, 
// when your array is not evenly divisible by the Vector width.

// When there will be no leftovers
var sum = myArray.SumS( x => x*x );   // Vector<T> has overrides for *, + etc

// When there will be leftovers
var sum = myArray.SumS(x=>x*x, x=>x*x); 

// As with the regular LinqFaster project, SIMD includes
// in place versions when appropriate:

myArray.SelectInPlaceS( v => v + new Vector(1));



```

### LinqFaster.Parallel

```c#

using JM.LinqFaster.Parallel;

// Parallel extension methods are all named with a P 
// at the end.

var sum = myList.SumP();

// Floating point math is not commutative, so the results
// of operations such as Sum and Average may differ slightly.
// Accuracy is usually better.

Console.WriteLine(myFloats.SumP() == myFloats.SumF()); // --> False!

// In some cases, unordered versions of a function are provided for
// better performance

myList.SelectUnorderedP(x => x*x);  

// All parallel functions have an optional batch size, which
// defines how many elements are operated on per task/thread.
// This can be tuned for performance.

myArray.Select(x=>x*x,myArray.Length/10);  //split the array into 10 ranges
myArray.Select(x=>x*x,10000); // split the array into ranges of 10,000 elements each

// Parallel functions cause some allocations, and requires care in their use, as they 
// may not be faster than scalar or SIMD versions depending on the workload and
// hardware available.
```

### LinqFaster.SIMD.Parallel

See MSDN [documentation](https://msdn.microsoft.com/en-us/library/dn858385(v=vs.111).aspx) on System.Numerics.Vectors
for more detail on SIMD in C#.

```c#

using LingFaster.SIMD.Parallel

// These functions combine SIMD acceleration and multithreading.
// They are all named with an SP at the end, and are available
// only for arrays.

var sum = myArray.SumSP();

// Floating point math is not commutative, so the results
// of operations such as Sum and Average may differ slightly.
// Accuracy is usually better.

Console.WriteLine(myFloats.SumSP() == myFloats.SumF()); // --> False!

// All SIMD parallel functions have an optional batch size, which
// defines how many elements are operated on per task/thread.
// This can be tuned for performance.

myArray.AverageSP(myArray.Length/10);  //split the array into 10 ranges
myArray.SelectSP(x=>x*x,10000); // split the array into ranges of 10,000 elements each


// SIMD operations are already very fast, so combining them with 
// multiple threads will only be worthwhile for large arrays and/or
// for very expensive operations.
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







