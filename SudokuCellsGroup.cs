using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Game
{
    public class SudokuCellGroup
    {
        public List<SudokuCell> cells;

        public List<SudokuCell> Cells => cells;

        public SudokuCellGroup()
        {
            cells = new List<SudokuCell>(9);
        }
               
        public bool Validate()
        {
            List<int> ints = new List<int>();

            for (int i = 0; i < cells.Count; i++)
            {
                if (cells[i] != null)
                {
                    if (ints.Contains(cells[i].Value))
                    {
                        return false;
                    }
                    else
                    {
                        ints.Add(cells[i].Value);
                    }
                }
            }
            return true;

        }


    }
}
