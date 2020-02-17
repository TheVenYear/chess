using System.Collections.Generic;
using System.Linq;

namespace ChessLibrary
{
    public enum FigureType
    {
        None = 0,
        Castle = 1,
        Queen = 2,
        Bishop = 3,
        Pawn = 4
    }

    public static class FigureTypeExtension
    {
        public static IEnumerable<Cell> GetMoves(this FigureType currentType,IEnumerable<Cell> field, Cell currentCell)
        {
            switch (currentType)
            {
                case FigureType.Castle:
                    foreach (var cell in field)
                    {
                        if (cell.X == currentCell.X || cell.Y == currentCell.Y)
                            yield return cell;
                    }
                    break;
                case FigureType.Bishop:

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
                        else if (cell.X == secDiagCell.X && cell.Y == secDiagCell.Y)
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
                    break;
            }
        }
    }
}
