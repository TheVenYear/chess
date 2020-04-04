using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class Bishop : IFigure
    {
        public bool IsBlack { get; set; }

        public Cell CurrentCell { get; set; }

        public IEnumerable<Cell> GetMoves(CellField field)
        {
            return FigureType.Bishop.GetMoves(field, CurrentCell);
        }
    }
}
