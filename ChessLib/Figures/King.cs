using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class King : IFigure
    {
        public bool IsBlack { get; set; }

        public Cell CurrentCell { get; set; }

        public IEnumerable<Cell> GetMoves(CellField field)
        {
            return FigureType.King.GetMoves(field, CurrentCell);
        }
    }
}
