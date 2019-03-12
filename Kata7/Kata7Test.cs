using System;
using System.Collections.Generic;
using System.Linq;
using kata;
using NUnit.Framework;

namespace Kata7 {

    [TestFixture]
    public sealed class Kata7Test {

        [TestCaseSource ("IsInvalidBlockData")]
        public void IsInvalidBlock (bool result, Block block, List<Block> blocks) => Assert.AreEqual (result, Kata7.IsInvalidBlock (block, blocks));

        public static IEnumerable<TestCaseData> IsInvalidBlockData () {
            yield return new TestCaseData (true, new Block (1, 10, 10), new List<Block> { new Block (1, 10, 10), new Block (1, 10, 12), new Block (1, 12, 10), new Block (1, 11, 10), new Block (1, 10, 9) });
            yield return new TestCaseData (false, new Block (1, 10, 10), new List<Block> { new Block (1, 10, 10), new Block (1, 10, 12), new Block (1, 12, 10), new Block (1, 11, 10), new Block (1, 10, 8) });
            yield return new TestCaseData (true, new Block (1, 10, 10), new List<Block> {
                new Block (1, 10, 10),
                new Block (1, 10, 12),
                new Block (1, 12, 10),
                new Block (1, 11, 10),
                new Block (1, 10, 8),
                new Block (1, 11, 11),
            });
        }

        [TestCaseSource ("ValidateBattlefieldData")]
        public void ValidateBattlefield (bool result, int[, ] array) => Assert.AreEqual (result, Kata7.ValidateBattlefield (array));

        public static IEnumerable<TestCaseData> ValidateBattlefieldData () {
            yield return new TestCaseData (true, new int[10, 10] { { 1, 0, 0, 0, 0, 1, 1, 0, 0, 0 }, { 1, 0, 1, 0, 0, 0, 0, 0, 1, 0 }, { 1, 0, 1, 0, 1, 1, 1, 0, 1, 0 }, { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 }, { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 }, { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            });
        }
    }
}