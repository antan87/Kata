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

        //     public static int DblLinear (int n) {
        //         if (n == 0)
        //             return 1;
        //         CalculateClass y = new CalculateClass (CalculateY);
        //         CalculateClass z = new CalculateClass (CalculateZ);
        //         List<int> result = new List<int> () { 1 };
        //         Stack stack = new Stack ();
        //         int? vY = y.FetchNext ();
        //         int? vZ = z.FetchNext ();
        //         List<int> list = new List<int> { 1 };
        //         int previousValue = 0;
        //         while (list.Count () <= n) {

        //             if (vY <= vZ) {

        //                 if (previousValue != vY.Value) {
        //                     list.Add (vY.Value);
        //                     previousValue = vY.Value;
        //                 }
        //                 y.Add (vY.Value);
        //                 z.Add (vY.Value);
        //                 vY = y.FetchNext ();

        //             } else if (vY > vZ) {

        //                 if (previousValue != vZ.Value) {
        //                     list.Add (vZ.Value);
        //                     previousValue = vZ.Value;
        //                 }

        //                 y.Add (vZ.Value);
        //                 z.Add (vZ.Value);
        //                 vZ = z.FetchNext ();

        //             }

        //         }
        //         return list.ElementAt (n);
        //     }
        //     public static Func<int, int> CalculateY => (x) => 2 * x + 1;
        //     public static Func<int, int> CalculateZ => (x) => 3 * x + 1;

        // }

        // public class Stack {
        //     private List<int> list = new List<int> () { 1 };
        //     public void Add (int value) {
        //         if (this.PreviousValue == value)
        //             return;

        //         int count = this.list.Count ();
        //         this.list.Insert (count == 0 ? 0 : count, value);
        //     }
        //     public int Pop () {

        //         int value = this.list.First ();
        //         if (this.PreviousValue == value) {
        //             this.list.RemoveAt (0);
        //             value = this.list.First ();
        //         }
        //         this.PreviousValue = value;
        //         this.list.RemoveAt (0);
        //         return value;

        //     }

        //     private int PreviousValue { get; set; }

        // }

        // public class CalculateClass {

        //     private Stack stack = new Stack ();
        //     private Func<int, int> CalculationMethod { get; }

        //     public void Add (int value) {
        //         stack.Add (value);
        //     }
        //     public CalculateClass (Func<int, int> method) {
        //         this.CalculationMethod = method;
        //     }

        //     public int FetchNext () {
        //         return CalculationMethod (stack.Pop ());
        //     }
        // }

        public static int DblLinear (int n) {

            var h = new int[++n];
            int x2 = 1, x3 = 1;
            int i = 0, j = 0;
            for (int index = 0; index < n; index++) {
                h[index] = x2 < x3 ? x2 : x3;
                if (h[index] == x2) x2 = 2 * h[i++] + 1;
                if (h[index] == x3) x3 = 3 * h[j++] + 1;
            }
            return h[--n];
        }
    }

    [TestFixture]
    public class Tests4 {

        [TestCase (22, 10)]
        [TestCase (91, 30)]
        [TestCase (175, 50)]

        public void DblLinear (int result, int x) => Assert.AreEqual (result, Kata4.DblLinear (x));
    }
}