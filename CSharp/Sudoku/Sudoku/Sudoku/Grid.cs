using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Sudoku
{
    public class Grid
    {
        public string Name;
        public Cell[][] Cells;

        public static Cell[][] FromInts(int[][] values)
        {
            return values.Select(row => row.Select(value => new Cell { Value = value })
                                           .ToArray())
                         .ToArray();
        }
    }
}
