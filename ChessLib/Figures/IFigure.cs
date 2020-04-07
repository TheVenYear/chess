using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public interface IFigure
    {
        FigureType Type { get; }

        Colour Colour { get; set; }

        bool IsFirstStep { get; set; }
    }
}
