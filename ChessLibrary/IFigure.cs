using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public interface IFigure
    {
        bool isBlack { get; set; }

        FigureType figure { get; set; }

        Cell currentCell { get; set; }

        IEnumerable<Cell> GetMoves(IEnumerable<Cell> field);

    }
}
