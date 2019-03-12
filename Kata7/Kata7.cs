// Write a method that takes a field for well-known board game "Battleship" as an argument and returns true if it has a valid disposition of ships, false otherwise. Argument is guaranteed to be 10*10 two-dimension array. Elements in the array are numbers, 0 if the cell is free and 1 if occupied by ship.

// Battleship (also Battleships or Sea Battle) is a guessing game for two players. Each player has a 10x10 grid containing several "ships" and objective is to destroy enemy's forces by targetting individual cells on his field. The ship occupies one or more cells in the grid. Size and number of ships may differ from version to version. In this kata we will use Soviet/Russian version of the game.

// Before the game begins, players set up the board and place the ships accordingly to the following rules:
// There must be single battleship (size of 4 cells), 2 cruisers (size 3), 3 destroyers (size 2) and 4 submarines (size 1). Any additional ships are not allowed, as well as missing ships.
// Each ship must be a straight line, except for submarines, which are just single cell.

// The ship cannot overlap or be in contact with any other ship, neither by edge nor by corner.

// This is all you need to solve this kata. If you're interested in more information about the game, visit this link https://en.wikipedia.org/wiki/Battleship_(game).

using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata7 {
    public static class Kata7 {
        public static bool ValidateBattlefield (int[, ] field) {

            List < (int size, int count) > rules = new List < (int size, int count) > {
                (size: 4, count: 1),
                (size: 3, count: 2),
                (size: 2, count: 3),
                (size: 1, count: 4)
            };

            List<Block> blocks = new List<Block> ();
            for (int y = 0; y < field.GetLength (0); y++)
                for (int x = 0; x < field.GetLength (1); x++)
                    blocks.Add (new Block (field[y, x], x, y));

            // Console.WriteLine (string.Join (Environment.NewLine, blocks.Select (row => $"X: {row.X} - Y: {row.Y} - Value:{row.Value}")));
            return true;
        }

        private static (bool isValid, List<Block> blocks) Validate ((int size, int count) rule, List<Block> blocks) {

            return (isValid: true, blocks = new List<Block> ());
        }

        public static bool IsInvalidBlock (Block block, List<Block> blocks) => Rules.Any (rule => rule (block, blocks));
        private static List<Func<Block, List<Block>, bool>> Rules =>
            new List<Func<Block, List<Block>, bool>> {
                (block, blocks) => blocks.Any (row => row.Value == 1 && ((block.X - 1 == row.X || block.X + 1 == row.X) && (block.Y - 1 == row.Y || block.Y + 1 == row.Y))),
                (block, blocks) => blocks.Any (row => row.Value == 1 && ((block.X - 1 == row.X || block.X + 1 == row.X) && blocks.Any (yRow => yRow.X == block.X && (block.Y - 1 == yRow.Y || block.Y + 1 == yRow.Y)))),

            };

    }
}