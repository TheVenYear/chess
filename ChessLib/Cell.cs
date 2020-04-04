using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class Cell
    {
        public Cell(int y, int x)
        {
            this.Y = y;
            this.X = x;
        }

        public int X { get; set; }

        public int Y { get; set; }

        private IFigure currentFigure;

        public IFigure CurrentFigure
        {
            get
            {
                return currentFigure;
            }

            set
            {
                if (currentFigure != null)
                    currentFigure.CurrentCell = null;
                currentFigure = value;
                currentFigure.CurrentCell = this;
            }
        }
    }
}
