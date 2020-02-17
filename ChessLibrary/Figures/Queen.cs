using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChessLibrary.Figures
{
    public class Queen : IFigure
    {
        public Cell currentCell { get; set; }

        public FigureType figure { get; set; } = FigureType.Queen;

        public bool isBlack { get; set; }

        public IEnumerable<Cell> GetMoves(IEnumerable<Cell> field)
        {
            return FigureType.Bishop.GetMoves(field, currentCell).Union(FigureType.Castle.GetMoves(field, currentCell));
        }
    }

}
