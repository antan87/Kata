using System.Collections.Immutable;
using System.Linq;
// Write a method that takes a field for well-known board game "Battleship" as an argument and returns true if it has a valid disposition of ships, false otherwise. Argument is guaranteed to be 10*10 two-dimension array. Elements in the array are numbers, 0 if the cell is free and 1 if occupied by ship.

// Battleship (also Battleships or Sea Battle) is a guessing game for two players. Each player has a 10x10 grid containing several "ships" and objective is to destroy enemy's forces by targetting individual cells on his field. The ship occupies one or more cells in the grid. Size and number of ships may differ from version to version. In this kata we will use Soviet/Russian version of the game.

// Before the game begins, players set up the board and place the ships accordingly to the following rules:
// There must be single battleship (size of 4 cells), 2 cruisers (size 3), 3 destroyers (size 2) and 4 submarines (size 1). Any additional ships are not allowed, as well as missing ships.
// Each ship must be a straight line, except for submarines, which are just single cell.

// The ship cannot overlap or be in contact with any other ship, neither by edge nor by corner.

// This is all you need to solve this kata. If you're interested in more information about the game, visit this link https://en.wikipedia.org/wiki/Battleship_(game).

using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace kata {

    public class BattleshipField {
        public static bool ValidateBattlefield (int[, ] field) {

            List<Block> blocks = new List<Block> ();
            for (int x = 0; x < field.GetLength (0); x++)
                for (int y = 0; y < field.GetLength (1); y++)
                    blocks.Add (new Block (field[x, y], x, y));

            return true;
        }
    }

    public sealed class Block {

        public Block (int value, int x, int y) {
            this.X = x;
            this.Y = y;
        }

        public int Value { get; }
        public int X { get; }
        public int Y { get; }

    }

    [TestFixture]
    public sealed class Tests7 {

        [TestCaseSource ("TestCaseSourceData")]
        public void FormatDuration (bool result, int[, ] array) => Assert.AreEqual (result, BattleshipField.ValidateBattlefield (array));

        public static IEnumerable<TestCaseData> TestCaseSourceData () {
            yield return new TestCaseData (true, new int[10, 10] { { 1, 0, 0, 0, 0, 1, 1, 0, 0, 0 }, { 1, 0, 1, 0, 0, 0, 0, 0, 1, 0 }, { 1, 0, 1, 0, 1, 1, 1, 0, 1, 0 }, { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 }, { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 }, { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            });
        }

    }
}