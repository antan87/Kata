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
using System.Threading.Tasks;
using NUnit.Framework;

namespace kata {
    public static class Kata4 {

        public static async Task<int> DblLinear (int n) {
            if (n == 0)
                return 1;

            Task<List<int>> yT = new List<int> { 1 }.Iter (CalculateY, n);
            Task<List<int>> zT = new List<int> { 1 }.Iter (CalculateZ, n);
            Task.WhenAll (new List<Task<List<int>>> { zT, yT });
            var yL = await yT;
            var zl = await zT;

            Task<List<int>> yXT2 = yL.XrossLists (CalculateZ);
            Task<List<int>> zXT2 = zl.XrossLists (CalculateY);
            Task.WhenAll (new List<Task<List<int>>> { yXT2, zXT2 });
            var yL2 = await yXT2;
            var zl2 = await zXT2;

            var xl = yL.Concat (zl).Concat (yL2).Concat (zl2).Distinct ().ToList ();
            xl.Sort ();
            return xl.ElementAt (n);
        }

        private static async Task<List<int>> XrossLists (this List<int> list, Func<int, int> func) {
            return list.Select (x => func (x)).ToList ();
        }
        public static IEnumerable<int> Calculate (List<int> list, Func<int, int> func) {
            return list.Select (x => func (x)).ToList ();
        }

        public static async Task<List<int>> Iter (this List<int> list, Func<int, int> func, int iterations) {
            if (iterations == 0)
                return list;
            iterations--;

            list.Add (func (list.LastOrDefault ()));
            return await list.Iter (func, iterations);
        }

        public static Func<int, int> CalculateY => (x) => 2 * x + 1;
        public static Func<int, int> CalculateZ => (x) => 3 * x + 1;
        // private static List<int> Iterate (List<int> list, int cursor, int n) {
        //     if (n == 0)
        //         return list;

        //     list.Insert (CalculateY (list[cursor]));
        //     n--;

        //     list.Add (CalculateZ (list[cursor]));
        //     n--;

        //     cursor++;
        //     return Iterate (list, cursor, n);
        // }

        public static List<int> Iterate2 (List<int> list, int n) {
            if (n == 0)
                return list;

            n--;

            List<int> newList = new List<int> ();
            newList.AddRange (Calculate (list, CalculateY));
            newList.AddRange (Calculate (list, CalculateZ));
            return Iterate2 (newList, n);
            // return Iterate2 (list, n);
        }

    }

    [TestFixture]
    public class Tests4 {

        [TestCase (22, 10)]
        [TestCase (91, 30)]
        public void DblLinear (int result, int x) => Assert.AreEqual (result, Kata4.DblLinear (x));
    }

}