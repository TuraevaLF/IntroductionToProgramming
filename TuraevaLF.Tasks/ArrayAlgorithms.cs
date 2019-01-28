using System;
using System.Linq;

namespace TuraevaLF.Tasks
{
    internal static class ArrayAlgorithms
    {
        internal static T[] SortBubble<T>(this T[] array) where T : IComparable
        {
            // procedure bubbleSort(A : list of sortable items )
            //     n = length(A)
            //     repeat
            //         newn = 0
            //         for i = 1 to n - 1 inclusive do
            //                     if A[i - 1] > A[i] then
            //   
            //                   swap(A[i - 1], A[i])
            //                 newn = i
            //             end if
            //         end for
            //         n = newn
            //     until n <= 1
            // end procedure

            int n = array.Length;

            do
            {
                int newn = 0;
                for (int i = 1; i < n - 1; i++)
                {
                    if (array[i - 1].CompareTo(array[i]) > 0)
                    {
                        array.Swap(i - 1, i);
                        newn = i;
                    }
                }
                n = newn;
            }
            while (n <= 1);

            return array;
        }


        internal static T[] SortInsertion<T>(this T[] array) where T : IComparable
        {
            // for i = 2 to n do
            //  x = A[i]
            //  j = i
            //  while (j > 1 and A[j - 1] > x) do 
            //      A[j] = A[j - 1]
            //      j = j - 1
            //  end while
            //  A[j] = x
            // end for

            for(int i = 1; i < array.Length; i++)
            {
                T x = array[i];
                int j = i;

                while(j > 0 && array[j - 1].CompareTo(x) > 0)
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = x;
            }
            return array;
        }

        internal static void Swap<T>(this T[] array, int index1, int index2)
        {
            T temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        internal static string AsString<T>(this T[] array)
        {
            return $"[{ string.Join(',', array.Select(v => v.ToString())) }]";
        }
    }
}
