using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class Pawn : IFigure
    {
        public Cell CurrentCell { get; set; }

        public bool IsBlack { get; set; }

        public IEnumerable<Cell> GetMoves(CellField field)
        {
            throw new NotImplementedException();
        }
    }
}
