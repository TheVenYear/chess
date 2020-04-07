using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class Pawn : IFigure
    {
        public FigureType Type { get; } = FigureType.Pawn;

        public Colour Colour { get; set; } = Colour.White;

        public bool IsFirstStep { get; set; } = true;
    }
}
