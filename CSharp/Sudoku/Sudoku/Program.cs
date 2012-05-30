using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sudoku.Sudoku;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            const string fileName = @"..\..\..\..\..\Data\Sudoku.txt";

            List<Grid> grids = ReaderWriter.Read(fileName);

            foreach (Grid grid in grids.Take(1))
            {
                Console.WriteLine(grid.AsString());
                Console.WriteLine("Solution:");
                Console.WriteLine(grid.AsString(showName: false));
                Console.WriteLine("\n\n");
            }
        }
    }
}
