using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary.Figures
{
    public class Bishop : IFigure
    {
        public bool isBlack { get; set; }
        public FigureType figure { get; set; } = FigureType.Bishop;
        public Cell currentCell { get; set; }

        public IEnumerable<Cell> GetMoves(IEnumerable<Cell> field)
        {
            foreach (var cell in field)
            {
                if (currentCell.X != cell.X && currentCell.Y != cell.Y)
                    yield return cell;
            }
        }
    }
}
