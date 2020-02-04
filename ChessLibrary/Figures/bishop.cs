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
            Cell mainDiagCell = new Cell(0, 0), secDiagCell = new Cell(0, 0);

            if (currentCell.X > currentCell.Y)
                mainDiagCell = new Cell(currentCell.X - currentCell.Y, 0);
            else if (currentCell.X < currentCell.Y)
                mainDiagCell = new Cell(0, currentCell.Y - currentCell.X);
            else
                mainDiagCell = new Cell(currentCell.X - currentCell.X, 0);

            if (currentCell.X + currentCell.Y <= field.Last().X)
                secDiagCell = new Cell(currentCell.X + currentCell.Y, 0);
            else
                secDiagCell = new Cell(field.Last().X, (currentCell.X + currentCell.Y) - field.Last().X);

            foreach (var cell in field)
            {
                if ((cell.X == mainDiagCell.X && cell.Y == mainDiagCell.Y)
                    && (cell.X == secDiagCell.X && cell.Y == secDiagCell.Y))
                {
                    mainDiagCell.X++;
                    mainDiagCell.Y++;
                    secDiagCell.X--;
                    secDiagCell.Y++;
                }
                else if(cell.X == secDiagCell.X && cell.Y == secDiagCell.Y)
                {
                    yield return cell;
                    secDiagCell.X--;
                    secDiagCell.Y++;
                }
                else if (cell.X == mainDiagCell.X && cell.Y == mainDiagCell.Y)
                {
                    yield return cell;
                    mainDiagCell.X++;
                    mainDiagCell.Y++;
                }

 
            }


        }
    }
}
