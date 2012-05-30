using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Sudoku
{
    public class Solver
    {
        public readonly Grid Puzzle;

        public Solver(Grid puzzle)
        {
            Puzzle = puzzle;
            hookUpEvents();
        }

        public Grid Solve()
        {
            return Puzzle;
        }

        private void hookUpEvents()
        {
            int i, j;
            for (i = 0; i < 9; i++)
            {
                RowGroups[i] = new CellGroup { Cells = Puzzle.Cells[i].ToArray() };
                for (j = 0; j < 9; j++)
                    Puzzle.Cells[i][j].ContainingGroups.Add(RowGroups[i]);
            }

            for (j = 0; j < 9; j++)
            {
                ColGroups[j] = new CellGroup { Cells = Puzzle.Cells.Select(row => row[j]).ToArray() };
                for (i = 0; i < 9; i++)
                    Puzzle.Cells[i][j].ContainingGroups.Add(ColGroups[j]);
            }
        }

        private CellGroup[] RowGroups = new CellGroup[9];
        private CellGroup[] ColGroups = new CellGroup[9];
        private CellGroup[] BoxGroups = new CellGroup[9];
    }
}
