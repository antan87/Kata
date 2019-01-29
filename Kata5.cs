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
            if (x != 0) {
                var firstArr = array.ToList ().Where ((item, ind) => ind < x).ToArray ();
                var secondArr = array.ToList ().Where ((item, ind) => ind >= x).ToArray ();
                // array = array.Except (firstArr).ToArray ();
                // firstArr.ToList ().ForEach (v => Console.WriteLine (v));
                // Console.WriteLine ("First");
                // array.ToList ().ForEach (v => Console.WriteLine (v));
                Array.Sort (secondArr);
                // array.ToList ().ForEach (v => Console.WriteLine (v));
                var nA = firstArr.Concat (secondArr);

                string newNumber = string.Empty;
                nA.ToList ().ForEach (xs => { newNumber += xs; });
                var ss = Convert.ToInt64 (newNumber);
                return ss == n ? -1 : ss;
            }
            // condtion = x + 1 != array.Length;
            // while (condtion) {

            //     if (array[x + 1] < array[x]) {
            //         Int64 temp = array[x];
            //         array.ToList ().ForEach (xc => Console.WriteLine ("X" + x + " Nr " + xc));
            //         array[x] = array[x + 1];
            //         array[x + 1] = temp;
            //     }
            //     x++;

            //     if (x + 1 == array.Length)
            //         condtion = false;
            // }
            return -1;
        }
    }

    [TestFixture]
    public class Tests5 {

        [TestCase (2071, 2017)]
        [TestCase (-1, 9999999999)]
        [TestCase (7012, 2710)]
        [TestCase (414, 144)]
        [TestCase (441, 414)]
        [TestCase (59884848483559, 5988484848359)]
        public void NextBiggerNumber (long result, long n) => Assert.AreEqual (result, Kata5.NextBiggerNumber (n));
    }
}