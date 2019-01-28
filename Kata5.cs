using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
namespace kata {

    public static class Kata5 {

        public static Int64 NextBiggerNumber (long n) {

            List<Int64> list = new List<Int64> ();
            foreach (var i in n.ToString ()) {
                list.Add ((Int64) Char.GetNumericValue (i));
            }
            Int64[] array = list.ToArray ();

            int x = array.Length - 1;
            bool condtion = true;
            while (condtion) {

                if (array[x - 1] < array[x]) {
                    condtion = false;
                    Int64 temp = array[x];
                    array[x] = array[x - 1];
                    array[x - 1] = temp;

                } else
                    x--;
                if (x - 1 < 0)
                    condtion = false;

            }

            condtion = x + 1 != array.Length;
            while (condtion) {

                if (array[x + 1] < array[x]) {
                    Int64 temp = array[x];
                    array.ToList ().ForEach (xc => Console.WriteLine ("X" + x + " Nr " + xc));
                    array[x] = array[x + 1];
                    array[x + 1] = temp;
                }
                x++;

                if (x + 1 == array.Length)
                    condtion = false;
            }
            string newNumber = string.Empty;
            array.ToList ().ForEach (xs => { newNumber += xs; });
            var ss = Convert.ToInt64 (newNumber);
            return ss == n ? -1 : ss;
        }
    }

    [TestFixture]
    public class Tests5 {

        [TestCase (2071, 2017)]
        [TestCase (-1, 9999999999)]
        [TestCase (7012, 2710)]
        public void NextBiggerNumber (long result, long n) => Assert.AreEqual (result, Kata5.NextBiggerNumber (n));
    }
}