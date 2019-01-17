// Consider a sequence u where u is defined as follows:

// The number u(0) = 1 is the first one in u.
// For each x in u, then y = 2 * x + 1 and z = 3 * x + 1 must be in u too.
// There are no other numbers in u.
// Ex: u = [1, 3, 4, 7, 9, 10, 13, 15, 19, 21, 22, 27, ...]

// 1 gives 3 and 4, then 3 gives 7 and 10, 4 gives 9 and 13, then 7 gives 15 and 22 and so on...

// Task:
// Given parameter n the function dbl_linear (or dblLinear...) returns the element u(n) of the ordered (with <) sequence u.

// Example:
// dbl_linear(10) should return 22

// Note:
// Focus attention on efficiency

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace kata {
    public static class Kata4 {

        public static int DblLinear (int n) {
            if (n == 0)
                return 1;

            var l = Iterate (new List<int> { 1 }, 0, n);
            return l.ElementAt (n);
        }

        private static List<int> Iterate (List<int> list, int cursor, int n) {
            if (n == 0)
                return list;

            list.Add (CalculateY (list[cursor]));
            list.Sort ();
            list.Add (CalculateZ (list[cursor]));
            list.Sort ();

            cursor++;
            n--;
            return Iterate (list, cursor, n);
        }

        public static Func<int, int> CalculateY => (x) => 2 * x + 1;
        public static Func<int, int> CalculateZ => (x) => 3 * x + 1;

    }

    [TestFixture]
    public class Tests4 {

        [TestCase (22, 10)]
        [TestCase (175, 50)]
        public void DblLinear (int result, int x) => Assert.AreEqual (result, Kata4.DblLinear (x));
    }

}