LinqFaster


Usage Guide
--------------------------------------------------------------------------
LinqFaster provides specialized versions of the Linq extensions methods
optimized for working with arrays and lists.  LinqFaster methods use the
same names as Linq, but with an F (for Fast) appended to them so that
you can use LinqFaster alongside regular Linq. The semantics are identical
except for OrderBy which does not do a stable sort like Linq does.

Examples
--------------------------------------------------------------------------
	//Create an array of with values -500 to 500
	var myArray = LinqFaster.RangeArrayF(-500, 500);
	//Create a List<T> with 1000 elements all set to 5.0
	var myList = LinqFaster.RepeatListF(5.0, 1000);

	//Compute sum, average, max,min
	var sum = myArray.SumF();
	var average = myArray.AverageF();
	var min = myArray.Min();
	var max = myArray.Max();

	//As above but on a transformation
	var sum2 = myArray.SumF(x => x*x);
	var average2 = myArray.AverageF(x => x*x);
	var min2 = myArray.Min(x => x*x);
	var max2 = myArray.Max(x => x*x);

	//Do a where and a select or select and where in a single pass
	var newArray = myArray.WhereSelectF(x => x % 2 == 0,x=>x*x);
	var newArray2 = myArray.SelectWhereF(x => x * x,x => x % 2 == 0);

	//Compute the sum of only the even values in a single pass
	var filteredSum = myArray.WhereAggregateF(x => x % 2 == 0, (acc, x) => acc + x);

	//New in-place methods are provided where appropriate
	myArray.SelectInPlace(x => x * x);
	myArray.ReverseInPlace();


Limitations
--------------------------------------------------------------------------
These are purely imperative implementations of the same higher order 
functions that Linq provides, but unlike Linq they are not lazily evaluated. 
This means that when chaining functions together such as:

var a = data.Where(predicate).Select(transform).Aggregate(foo);
// or
var b = data.Select(selector).Sum();

Linq would not do any work until the calls to Sum() or Aggregate(), and thus 
iterate over the collection only once and allocate very little. LinqFaster 
used this way would iterate over the collection each time and allocate much 
more. Sometimes the net result will still be faster overall but the better 
approach is to use the combined LinqFaster operations such as 
SelectWhere, WhereSelect, and WhereAggregate. For example the expressions 
above would become:

var a = data.WhereAggregate(predicate,transform,foo);
// and
var b = data.Sum(selector);

This gets you the best of both worlds. The speed of memory locality and no 
allocations at all. In short, think about how you are transforming your 
data. In some cases normal Linq may be the better choice.

