using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class Cell
    {
        public Cell(PlayGround playGround, int posY, int posX)
        {
            PosX = posX;
            PosY = posY;
            PlayGround = playGround;
        }

        public PlayGround PlayGround { get; private set; }

        public IFigure Figure { get; set; } = new None();

        public int PosX { get; private set; }

        public int PosY { get; private set; }

        public IEnumerable<Cell> GetLine(int stepY, int stepX)
        {
            var status = true;
            int counterY = PosY + stepY, counterX = PosX + stepX;

            while (status)
            {
                if (PlayGround[counterY, counterX] == null || PlayGround[counterY, counterX].Figure.Colour == Figure.Colour)
                {
                    status = false;
                    continue;
                }
                if (PlayGround[counterY, counterX].Figure.Colour != Colour.None && PlayGround[counterY, counterX].Figure.Colour != Figure.Colour)
                {
                    yield return PlayGround[counterY, counterX];
                    status = false;
                    continue;
                }

                yield return PlayGround[counterY, counterX];
                counterY += stepY;
                counterX += stepX;
            }
        }

        public Cell GetCell(int stepY, int stepX)
        {
            if (PlayGround[PosY + stepY, PosX + stepX] != null && PlayGround[PosY + stepY, PosX + stepX].Figure.Colour != Figure.Colour)
            {
                return PlayGround[PosY + stepY, PosX + stepX];
            }

            else
            {
                return null;
            }

        }

        public IEnumerable<Cell> GetMoves()
        {
            return Figure.Type.GetMoves(this);
        }
    }
}
