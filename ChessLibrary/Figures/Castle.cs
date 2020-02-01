using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary.Figures
{
    public class Castle : IFigure
    {
        public bool isBlack { get; set; }

        public FigureType figure { get; set; } = FigureType.Castle;

        public Cell currentCell { get; set; }

        public IEnumerable<Cell> GetMoves(IEnumerable<Cell> field)
        {
            foreach (var cell in field)
            {
                if (cell.X == currentCell.X || cell.Y == currentCell.Y)
                    yield return cell;
            }
        }
    }
}
