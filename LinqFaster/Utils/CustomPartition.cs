#if !(UNITY_4 || UNITY_5)
using System;
using System.Collections.Concurrent;


namespace JM.LinqFaster.Utils
{
    internal static class CustomPartition
    {
        public static OrderablePartitioner<Tuple<int,int>> MakePartition(int len, int? batchSize)
        {
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