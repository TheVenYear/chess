using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary.Figures
{
    class Pawn : IFigure
    {
        public Cell currentCell { get; set; }

        public FigureType figure { get; set; } = FigureType.Pawn;

        public bool isBlack { get; set; }

        public IEnumerable<Cell> GetMoves(IEnumerable<Cell> field)
        {
            throw new NotImplementedException();
        }
    }
}
