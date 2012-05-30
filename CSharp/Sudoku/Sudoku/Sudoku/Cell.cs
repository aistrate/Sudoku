using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Sudoku
{
    public class Cell
    {
        public int Value;

        public List<CellGroup> ContainingGroups = new List<CellGroup>();

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
