using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class None : IFigure
    {
        public FigureType Type { get; } = FigureType.None;

        public Colour Colour { get; set; } = Colour.None;

        public bool IsFirstStep { get; set; } = false;
    }
}
