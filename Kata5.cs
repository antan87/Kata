using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;
namespace kata {

    public static class Kata5 {

        public static Int64 NextBiggerNumber (long n) {
            Int64[] array = n.ToString ().ToList ().Select (row => (Int64) Char.GetNumericValue (row)).ToArray ();
            int x = array.Length - 1;
            bool condtion = true;
            while (condtion) {

                long valueX = array[x];
                long higherValue = array.Where ((item, index) => x < index && valueX < item).OrderBy (item => item).FirstOrDefault ();

                if (higherValue != 0) {
                    var index = Array.FindIndex (array, x + 1, row => row == higherValue);
                    array[x] = array[index];
                    array[index] = valueX;
                    Array.Sort (array, x + 1, array.Length - (x + 1));
                    condtion = false;
                } else {
                    x--;
                    if (x < 0)
                        condtion = false;
                }
            }
            long newNumber = Convert.ToInt64 (string.Join ("", array.Select (row => Convert.ToString (row))));
            return newNumber == n ? -1 : newNumber;
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
        [TestCase (1234567980, 1234567908)]
        [TestCase (504546, 504465)]
        public void NextBiggerNumber (long result, long n) => Assert.AreEqual (result, Kata5.NextBiggerNumber (n));
    }
}