using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
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
                    Int64 temp2 = array[x - 1];
                    Int64? ndd = array.ToList ().Where ((row, index) => index > x && row < temp && temp2 < row).FirstOrDefault ();
                    if (ndd.HasValue) {

                        array.ToList ().Where ((row, index) => index > x && row < temp && temp2 < row).FirstOrDefault ();

                        array[x] = temp2;
                        array[x - 1] = ndd.Value;
                        var ss = array.ToList ();
                        ss.Add (temp);
                        array = ss.ToArray ();
                    } else {

                        array[x] = array[x - 1];
                        array[x - 1] = temp;
                    }
                } else
                    x--;
                if (x - 1 < 0)
                    condtion = false;

            }
            if (x != 0) {
                var firstArr = array.ToList ().Where ((item, ind) => ind < x).ToArray ();
                var secondArr = array.ToList ().Where ((item, ind) => ind >= x).ToArray ();
                Array.Sort (secondArr);
                var nA = firstArr.Concat (secondArr);

                string newNumber = string.Empty;
                nA.ToList ().ForEach (xs => { newNumber += xs; });
                var ss = Convert.ToInt64 (newNumber);
                return ss == n ? -1 : ss;
            }

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
        [TestCase (123465, 123456)]
        // [TestCase (1234567908, 1234567980)]
        [TestCase (504465, 504546)]
        [TestCase (504546, 504465)]
        public void NextBiggerNumber (long result, long n) => Assert.AreEqual (result, Kata5.NextBiggerNumber (n));
    }
}