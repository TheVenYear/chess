using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class Castle : IFigure
    {
        public bool IsBlack { get; set; }

        public Cell CurrentCell { get; set; }

        public IEnumerable<Cell> GetMoves(CellField field)
        {
            return FigureType.Castle.GetMoves(field, CurrentCell);
        }
    }
}
