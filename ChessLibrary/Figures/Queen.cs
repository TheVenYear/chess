using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary.Figures
{
    public class Queen : IFigure
    {
        public Cell currentCell { get; set; }

        public FigureType figure { get; set; } = FigureType.Queen;

        public bool isBlack { get; set; }

        public IEnumerable<Cell> GetMoves(IEnumerable<Cell> field)
        {
            var castle = new Castle();
            castle.currentCell = currentCell;
            var bishop = new Bishop();
            bishop.currentCell = currentCell;
            return castle.GetMoves(field).Union(bishop.GetMoves(field));
        }
    }
}
