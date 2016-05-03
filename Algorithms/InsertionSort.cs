using System;

namespace Algorithms
{
    public static class InsertionSort
    {
        public static void Sort<T>(T[] array) where T : IComparable
        {
            if (array == null)
                throw new ArgumentException("Input array was null", nameof(array));

            if (array.Length <= 1)
                return;

            // Insert array[j] into sorted sequence array[j - 1]
            for (var j = 1; j < array.Length; ++j)
            {
                var key = array[j];
                var i = j - 1;
                while (i >= 0 && array[i].CompareTo(key) > 0)
                {
                    array[i + 1] = array[i];
                    i--;
                }
                array[i + 1] = key;
            }
        }
    }
}
