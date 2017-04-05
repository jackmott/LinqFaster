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
    }
}
