#if !(UNITY_4 || UNITY_5)
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace JM.LinqFaster.Utils
{
    internal class EmptyOrderablePartitioner<T> : OrderablePartitioner<T>
    {
        // Constructor just grabs the collection to wrap
        public EmptyOrderablePartitioner()
            : base(true, true, true)
        {                        
        }

        public override IList<IEnumerator<KeyValuePair<long, T>>> GetOrderablePartitions(int partitionCount)
        {
            return new List<IEnumerator<KeyValuePair<long, T>>>();
        }

        
        public override IEnumerable<KeyValuePair<long, T>> GetOrderableDynamicPartitions()
        {            
            return new List<KeyValuePair<long, T>>();
        }

        // Must be set to true if GetDynamicPartitions() is supported.
        public override bool SupportsDynamicPartitions {
            get { return true; }
        }
    }

    internal static class CustomPartition
    {
        public static OrderablePartitioner<Tuple<int,int>> MakePartition(int len, int? batchSize)
        {
            if (len == 0) return new EmptyOrderablePartitioner<Tuple<int, int>>();

            if (batchSize == null)
            {
                return Partitioner.Create(0, len);
            }            
            else
            {
                return Partitioner.Create(0, len, batchSize.Value);
            }
        }
      
        public static OrderablePartitioner<Tuple<int, int>> MakeSIMDPartition(int len, int chunkSize, int? batchSize)
        {
            if (len == 0) return new EmptyOrderablePartitioner<Tuple<int, int>>();

            int chunkLen = len - len % chunkSize;
            int numChunks = chunkLen / chunkSize;
            if (batchSize == null)
            {                
                return Partitioner.Create(0, numChunks,numChunks/Environment.ProcessorCount);
            }            
            else
            {
                return Partitioner.Create(0, numChunks, batchSize.Value);
            }
        }

    }
}
#endif