using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class Cell
    {
        public Cell(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public int X { get; set; }

        public int Y { get; set; }

        private IFigure _currentFigure;

        public IFigure currentFigure
        {
            get
            {
                return _currentFigure;
            }

            set
            {
                if (_currentFigure != null)
                    _currentFigure.currentCell = null;
                _currentFigure = value;
                _currentFigure.currentCell = this;
            }
        } 
    }
}
