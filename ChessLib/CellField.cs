using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class CellField : IEnumerable<Cell>
    {
        public Cell this[int y, int x]
        {
            get
            {
                if (cells.Exists(cell => cell.X == x && cell.Y == y))
                {
                    return cells[cells.FindIndex(cell => cell.X == x && cell.Y == y)];
                }

                return new Cell(0, 0);
            }
            set
            {
                if (cells.Exists(cell => cell.X == x && cell.Y == y))
                {
                    cells[cells.FindIndex(cell => cell.X == x && cell.Y == y)] = value;
                }
            }
        }

        private List<Cell> cells = new List<Cell>();

        public CellField()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    cells.Add(new Cell(j, i));
                }
            }
        }

        public bool ExcistsAt(int y, int x)
        {
            if (cells.Exists(cell => cell.Y == y && cell.X == x))
            {
                return true;
            }

            return false;
        }

        public IEnumerator<Cell> GetEnumerator()
        {
            foreach (var cell in cells)
            {
                yield return cell;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return cells.GetEnumerator();
        }

    }
}
