// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace JM.LinqFaster
{
    /// <summary>
    /// A lightweight hash set.
    /// </summary>
    /// <typeparam name="TElement">The type of the set's items.</typeparam>
    public sealed class FastSet<TElement>
    {
        /// <summary>
        /// The comparer used to hash and compare items in the set.
        /// </summary>
        private readonly IEqualityComparer<TElement> _comparer;

        /// <summary>
        /// The hash buckets, which are used to index into the slots.
        /// </summary>
        private int[] _buckets;

        /// <summary>
        /// The slots, each of which store an item and its hash code.
        /// </summary>
        private Slot[] _slots;
        private TElement[] _values;

        /// <summary>
        /// The number of items in this set.
        /// </summary>
        private int _count;



        /// <summary>
        /// Constructs a set that compares items with the specified comparer.
        /// </summary>
        /// <param name="comparer">
        /// The comparer. If this is <c>null</c>, it defaults to <see cref="EqualityComparer{TElement}.Default"/>.
        /// </param>
        public FastSet(IEqualityComparer<TElement> comparer)
        {
            _comparer = comparer ?? EqualityComparer<TElement>.Default;
            _buckets = new int[7];
            _slots = new Slot[7];
            _values = new TElement[7];
        }

        /// <summary>
        /// Attempts to add an item to this set.
        /// </summary>
        /// <param name="value">The item to add.</param>
        /// <returns>
        /// <c>true</c> if the item was not in the set; otherwise, <c>false</c>.
        /// </returns>
        public void Add(TElement value)
        {
            int hashCode = InternalGetHashCode(value);
            for (int i = _buckets[hashCode % _buckets.Length] - 1; i >= 0; i = _slots[i]._next)
            {
                if (_slots[i]._hashCode == hashCode && _comparer.Equals(_values[i], value))
                {
                    return;
                }
            }

            if (_count == _slots.Length)
            {
                Resize();
            }

            int index = _count;
            _count++;
            int bucket = hashCode % _buckets.Length;
            _slots[index]._hashCode = hashCode;            
            _slots[index]._next = _buckets[bucket] - 1;
            _values[index] = value;
            _buckets[bucket] = index + 1;            
        }

      
        /// <summary>
        /// Expands the capacity of this set to double the current capacity, plus one.
        /// </summary>
        private void Resize()
        {
            int newSize = checked((_count * 2) + 1);
            int[] newBuckets = new int[newSize];
            Slot[] newSlots = new Slot[newSize];
            var newValues = new TElement[newSize];
            Array.Copy(_slots, 0, newSlots, 0, _count);
            Array.Copy(_values, 0, newValues, 0, _count);
            for (int i = 0; i < _count; i++)
            {
                int bucket = newSlots[i]._hashCode % newSize;
                newSlots[i]._next = newBuckets[bucket] - 1;                
                newBuckets[bucket] = i + 1;
            }
            _values = newValues;
            _buckets = newBuckets;
            _slots = newSlots;
        }

        /// <summary>
        /// Creates an array from the items in this set.
        /// </summary>
        /// <returns>An array of the items in this set.</returns>
        public TElement[] ToArray()
        {
#if DEBUG
            Debug.Assert(!_haveRemoved, "Optimised ToArray cannot be called if Remove has been called.");
#endif

            Array.Resize(ref _values, _count);
            return _values;
        }

       

        /// <summary>
        /// The number of items in this set.
        /// </summary>
        public int Count => _count;

      

        /// <summary>
        /// Gets the hash code of the provided value with its sign bit zeroed out, so that modulo has a positive result.
        /// </summary>
        /// <param name="value">The value to hash.</param>
        /// <returns>The lower 31 bits of the value's hash code.</returns>
        private int InternalGetHashCode(TElement value)
        {
            // Handle comparer implementations that throw when passed null
            return (value == null) ? 0 : _comparer.GetHashCode(value) & 0x7FFFFFFF;
        }

        /// <summary>
        /// An entry in the hash set.
        /// </summary>
        internal struct Slot
        {
            /// <summary>
            /// The hash code of the item.
            /// </summary>
            internal int _hashCode;

            /// <summary>
            /// In the case of a hash collision, the index of the next slot to probe.
            /// </summary>
            internal int _next;            
        }
    }
}