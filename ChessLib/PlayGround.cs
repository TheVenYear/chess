using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class PlayGround : IEnumerable<Cell>
    {
        Cell[,] cells;

        public int VerSize { get; set; }

        public int HorSize { get; set; }

        public PlayGround(int verSize = 8, int horSize = 8)
        {
            VerSize = verSize;
            HorSize = horSize;
            cells = new Cell[VerSize, HorSize];

            for (int i = 0; i < VerSize; i++)
            {
                for (int j = 0; j < HorSize; j++)
                {
                    cells[i, j] = new Cell(this, i, j);
                }
            }

            cells[0, 0].Figure = new Castle() { Colour = Colour.Black };
            cells[1, 0].Figure = new Pawn() { Colour = Colour.White };
        }

        public Cell this[int y, int x]
        {
            get
            {
                try
                {
                    cells.GetValue(y, x);
                }
                catch
                {
                    return null;
                }

                return (Cell)cells.GetValue(y, x);

            }

            set
            {
                cells[y, x] = value;
            }
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
            foreach (var cell in cells)
            {
                yield return cell;
            }
        }
    }
}
