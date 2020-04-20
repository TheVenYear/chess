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

        public Colour CurrentPlayer { get; private set; } = Colour.White;

        public event Action<Colour> ThrowWin;

        public int VerSize { get; set; }

        public int HorSize { get; set; }

        public bool Move(Cell from, Cell to)
        {
            if (!from.GetMoves().Contains(to) || CurrentPlayer != from.Figure.Colour)
            {
                return false;
            }

            from.Figure.IsFirstStep = false;
            to.Figure = from.Figure;
            from.Figure = new None();
            CurrentPlayer = CurrentPlayer.TakeOpposite();
            WinCheck();
            return true;
        }

        public void WinCheck()
        {
            var kings = this.Where(item => item.Figure.Type == FigureType.King);
            if (!(kings.Contains(FigureType.King) && kings.Where(cell => cell.Figure.Colour == Colour.White).Any()))
            {
                ThrowWin?.Invoke(Colour.Black);
                BuildGround(VerSize, HorSize);
            }

            else if (!(kings.Contains(FigureType.King) && kings.Where(cell => cell.Figure.Colour == Colour.Black).Any()))
            {
                ThrowWin?.Invoke(Colour.White);
            }
        }

        private void BuildGround(int verSize, int horSize)
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
            cells[0, 1].Figure = new Knight() { Colour = Colour.Black };
            cells[0, 2].Figure = new Bishop() { Colour = Colour.Black };
            cells[0, 3].Figure = new Queen() { Colour = Colour.Black };
            cells[0, 4].Figure = new King() { Colour = Colour.Black };
            cells[0, 5].Figure = new Bishop() { Colour = Colour.Black };
            cells[0, 6].Figure = new Knight() { Colour = Colour.Black };
            cells[0, 7].Figure = new Castle() { Colour = Colour.Black };

            for (int i = 0; i < VerSize; i++)
            {
                cells[1, i].Figure = new Pawn() { Colour = Colour.Black };
            }

            for (int i = 0; i < VerSize; i++)
            {
                cells[6, i].Figure = new Pawn() { Colour = Colour.White };
            }

            cells[7, 0].Figure = new Castle() { Colour = Colour.White };
            cells[7, 1].Figure = new Knight() { Colour = Colour.White };
            cells[7, 2].Figure = new Bishop() { Colour = Colour.White };
            cells[7, 3].Figure = new Queen() { Colour = Colour.White };
            cells[7, 4].Figure = new King() { Colour = Colour.White };
            cells[7, 5].Figure = new Bishop() { Colour = Colour.White };
            cells[7, 6].Figure = new Knight() { Colour = Colour.White };
            cells[7, 7].Figure = new Castle() { Colour = Colour.White };
        }

        public PlayGround(int verSize = 8, int horSize = 8)
        {
            BuildGround(verSize, horSize);
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
