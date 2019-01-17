// The maximum sum subarray problem consists in finding the maximum sum of a contiguous subsequence in an array or list of integers:

// maxSequence [-2, 1, -3, 4, -1, 2, 1, -5, 4]
// -- should be 6: [4, -1, 2, 1]
// Easy case is when the list is made up of only positive numbers and the maximum sum is the sum of the whole array. If the list is made up of only negative numbers, return 0 instead.

// Empty list is considered to have zero greatest sum. Note that the empty list or array is also a valid sublist/subarray.

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace kata {

    public static class Kata3 {

        public static int MaxSequence (int[] arr) {
            //TODO : create code
            Tuple<int, int, int> highestValue = new Tuple<int, int, int> (0, 0, 0);
            for (int i = 0; i < arr.Length; i++) {
                List<int> values = new List<int> ();
                for (int k = i; k < arr.Length; k++) {
                    values.Add (arr[k]);
                    if (values.Sum () > highestValue.Item3) {
                        highestValue = new Tuple<int, int, int> (i, k, values.Sum ());
                    }
                }

            }

            return highestValue.Item3;
        }

    }

    [TestFixture]
    public class Tests2 {

        [TestCase (6, new int[] {-2, 1, -3, 4, -1, 2, 1, -5, 4 })]
        [TestCase (0, new int[0])]
        public void MaxSequence (double result, int[] arr) => Assert.AreEqual (result, Kata3.MaxSequence (arr));
    }
}