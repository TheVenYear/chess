using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public enum FigureType
    {
        None,
        Castle,
        Queen,
        Bishop,
        Pawn,
        King
    }

    public static class FigureTypeExtension
    {
        public static IEnumerable<Cell> GetMoves(this FigureType currentType, CellField field, Cell currentCell)
        {
            switch (currentType)
            {
                case FigureType.Castle:
                    foreach (var cell in field.Where(cell => cell.X == currentCell.X || cell.Y == currentCell.Y))
                    {
                        yield return cell;
                    }
                    break;

                case FigureType.Bishop:
                    var counter = 0;

                    while (field.ExcistsAt(currentCell.Y + counter, currentCell.X + counter) &&
                            field.ExcistsAt(currentCell.Y - counter, currentCell.X - counter) &&
                            field.ExcistsAt(currentCell.Y - counter, currentCell.X + counter) &&
                            field.ExcistsAt(currentCell.Y + counter, currentCell.X - counter))
                    {
                        yield return field[currentCell.Y + counter, currentCell.X + counter];
                        yield return field[currentCell.Y - counter, currentCell.X - counter];
                        yield return field[currentCell.Y - counter, currentCell.X + counter];
                        yield return field[currentCell.Y + counter, currentCell.X - counter];
                        counter++;
                    }

                    break;

                case FigureType.King:
                    for (int i = currentCell.Y - 1; i <= currentCell.Y + 1; i++)
                    {
                        for (int j = currentCell.X - 1; j <= currentCell.X + 1; j++)
                        {
                            yield return field[i, j];
                        }
                    }
                    break;
            }
        }
    }
}
