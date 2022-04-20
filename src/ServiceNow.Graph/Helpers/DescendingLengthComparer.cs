using System;
using System.Collections.Generic;

namespace ServiceNow.Graph.Helpers
{
    /// <summary>
    /// Used for sorting strings in descending length
    /// </summary>
    public class DescendingLengthComparer : Comparer<string>
    {
        /// <summary>
        /// Returns -1 if the length of key1 is larger than key2
        /// Returns 0 if the lengths of both arguments is the same
        /// Returns 1 if the length of key1 is smaller than key2
        /// </summary>
        /// <param name="key1"></param>
        /// <param name="key2"></param>
        /// <exception cref="ArgumentException"></exception>
        public override int Compare(string key1, string key2)
        {
            if (key1 == null || key2 == null)
            {
                throw new ArgumentException("Arguments must both be non null");
            }

            var lengthOfKey1 = key1.Length;
            var lengthOfKey2 = key2.Length;
            if (lengthOfKey1 == lengthOfKey2) return 0;
            if (lengthOfKey1 > lengthOfKey2) return -1;
            return 1;
        }
    }
}
