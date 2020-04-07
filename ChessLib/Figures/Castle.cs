using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class Castle : IFigure
    {
        public FigureType Type { get; } = FigureType.Castle;

        public Colour Colour { get; set; } = Colour.White;

        public bool IsFirstStep { get; set; } = true;
    }
}
