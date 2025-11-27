LinqFaster


Usage Guide
--------------------------------------------------------------------------
LinqFasterSpan provides specialized versions of the Linq extensions methods
optimized for working with Span<T> and ReadOnlySpan<T>.  LinqFaster methods use the
same names as Linq, but with an F (for Fast) appended to them so that
you can use LinqFaster alongside regular Linq. The semantics are identical
except for OrderBy which does not do a stable sort like Linq does.

Examples
--------------------------------------------------------------------------
	


Limitations
--------------------------------------------------------------------------
These are purely imperative implementations of the same higher order 
functions that Linq provides, but unlike Linq they are not lazily evaluated. 
This means that when chaining functions together such as:
