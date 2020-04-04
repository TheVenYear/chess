using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public interface IFigure
    {
        bool IsBlack { get; set; }

        Cell CurrentCell { get; set; }

        IEnumerable<Cell> GetMoves(CellField field);
    }
}
