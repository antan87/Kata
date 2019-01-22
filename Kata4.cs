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

            CalculateClass y = new CalculateClass (CalculateY);
            CalculateClass z = new CalculateClass (CalculateZ);
            // List<CalculateClass> calcMethods = new List<CalculateClass> { y, z };
            List<int> result = new List<int> () { 1 };
            int ewqual = 0;
            while (result.Count () <= n) {

                var vY = y.PreviewNext ();
                var vZ = z.PreviewNext ();
                if (vY.HasValue && vY < vZ) {
                    y.FetchNext ();
                    if (!result.Contains (vY.Value)) {
                        result.Add (vY.Value);
                    } else
                        ewqual++;

                    y.Add (vY.Value);
                    z.Add (vY.Value);
                } else {
                    z.FetchNext ();
                    if (!result.Contains (vZ.Value)) {
                        result.Add (vZ.Value);

                    } else
                        ewqual++;

                    y.Add (vZ.Value);
                    z.Add (vZ.Value);
                }

            }

            return result.ElementAt (n);
        }
        public static Func<int, int> CalculateY => (x) => 2 * x + 1;
        public static Func<int, int> CalculateZ => (x) => 3 * x + 1;

    }

    public class Stack {
        HashSet<int> list = new HashSet<int> () { 1 };
        public void Add (int value) {
            if (this.list.Contains (value))
                return;

            this.list.Add (value);

        }
        public int Pop () {
            if (!this.list.Any ())
                return 0;

            int value = this.list.Min ();
            this.list.Remove (value);
            return value;

        }

        public void Remove (int value) {
            this.list.Remove (value);

        }

        public int? Peek () {
            if (!this.list.Any ())
                return null;

            return this.list.Min ();

        }

    }

    public class CalculateClass {

        Stack stack = new Stack ();

        Func<int, int> CalcMethod { get; }

        public void Add (int value) {
            stack.Add (value);
        }
        public CalculateClass (Func<int, int> method) {
            this.CalcMethod = method;
        }

        public int? PreviewNext () {
            var peek = stack.Peek ();
            if (!peek.HasValue)
                return null;
            return CalcMethod (peek.Value);
        }
        public void Remove (int value) {
            stack.Remove (value);
        }
        public int FetchNext () {
            return CalcMethod (stack.Pop ());
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