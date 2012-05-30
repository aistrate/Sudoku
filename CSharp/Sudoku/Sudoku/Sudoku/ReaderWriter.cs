using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Sudoku.Sudoku
{
    public static class ReaderWriter
    {
        public static List<Grid> Read(string fileName)
        {
            try
            {
                List<string> lines = readLines(fileName).ToList();
                List<Grid> grids = new List<Grid>();

                for (int i = 0; i < lines.Count; )
                {
                    Grid grid = new Grid
                    {
                        Name = lines[i++],
                    };

                    int[][] values = new int[9][];
                    for (int j = 0; j < 9; j++)
                        values[j] = lines[i++].Select(c => int.Parse(c.ToString())).ToArray();

                    grid.Cells = Grid.FromInts(values);

                    grids.Add(grid);
                }

                return grids;
            }
            catch (Exception e)
            {
                Console.WriteLine("File '{0}' could not be read:", fileName);
                Console.WriteLine(e.Message);
                return new List<Grid>();
            }
        }

        private static IEnumerable<string> readLines(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        public static string AsString(this Grid grid, string rowSeparator = "\n", string colSeparator = ", ", bool showName = true)
        {
            IEnumerable<string> rows = showName ? new string[] { grid.Name } : new string[0];

            rows = rows.Concat(grid.Cells.Select(row => string.Join(colSeparator, row.Select(cell => cell.ToString()))));

            return string.Join(rowSeparator, rows);
        }
    }
}
