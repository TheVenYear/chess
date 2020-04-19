using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public static class ChessExtensions
    {
        public static void AddCell(this List<Cell> list, Cell currentCell, int stepY, int stepX)
        {
            if (currentCell.GetCell(stepY, stepX) != null)
            {
                list.Add(currentCell.GetCell(stepY, stepX));
            }
        }

        public static Colour TakeOpposite(this Colour colour)
        {
            if (colour == Colour.White)
            {
                return Colour.Black;
            }

            else
            {
                return Colour.White;
            }
        }

        public static IEnumerable<Cell> GetMoves(this FigureType figure, Cell currentCell)
        {
            var result = new List<Cell>();

            switch (figure)
            {
                case FigureType.Castle:
                    result.AddRange(currentCell.GetLine(0, -1));
                    result.AddRange(currentCell.GetLine(-1, 0));
                    result.AddRange(currentCell.GetLine(0, 1));
                    result.AddRange(currentCell.GetLine(1, 0));
                    break;
                case FigureType.Bishop:
                    result.AddRange(currentCell.GetLine(-1, -1));
                    result.AddRange(currentCell.GetLine(1, 1));
                    result.AddRange(currentCell.GetLine(1, -1));
                    result.AddRange(currentCell.GetLine(-1, 1));
                    break;
                case FigureType.Knight:
                    result.AddCell(currentCell, 2, 1);
                    result.AddCell(currentCell, 2, -1);
                    result.AddCell(currentCell, -2, 1);
                    result.AddCell(currentCell, -2, -1);
                    result.AddCell(currentCell, 1, 2);
                    result.AddCell(currentCell, -1, 2);
                    result.AddCell(currentCell, 1, -2);
                    result.AddCell(currentCell, -1, -2);
                    break;
                case FigureType.King:
                    result.AddCell(currentCell, -1, 0);
                    result.AddCell(currentCell, 1, 0);
                    result.AddCell(currentCell, 0, 1);
                    result.AddCell(currentCell, 0, -1);
                    break;
                case FigureType.Queen:
                    result.AddRange(FigureType.Bishop.GetMoves(currentCell));
                    result.AddRange(FigureType.Castle.GetMoves(currentCell));
                    break;
                case FigureType.Pawn:
                    if (currentCell.Figure.Colour == Colour.White)
                    {
                        if (currentCell.GetCell(-1, 0) != null && currentCell.GetCell(-1, 0).Figure.Type == FigureType.None)
                        {
                            result.AddCell(currentCell, -1, 0);
                        }
                        if (currentCell.Figure.IsFirstStep && result.Contains(currentCell.GetCell(-1, 0)))
                        {
                            result.AddCell(currentCell, -2, 0);
                        }
                        var cell = currentCell.PlayGround[currentCell.PosY - 1, currentCell.PosX - 1];
                        if (cell != null && cell.Figure.Colour != currentCell.Figure.Colour && cell.Figure.Colour != Colour.None)
                        {
                            result.AddCell(currentCell, -1, -1);
                        }

                        cell = currentCell.PlayGround[currentCell.PosY - 1, currentCell.PosX + 1];
                        if (cell != null && cell.Figure.Colour != currentCell.Figure.Colour && cell.Figure.Colour != Colour.None)
                        {
                            result.AddCell(currentCell, -1, 1);
                        }
                    }
                    else
                    {
                        if (currentCell.GetCell(1, 0) != null && currentCell.GetCell(1, 0).Figure.Type == FigureType.None)
                        {
                            result.AddCell(currentCell, 1, 0);
                        }

                        if (currentCell.Figure.IsFirstStep && result.Contains(currentCell.GetCell(1, 0)))
                        {
                            result.AddCell(currentCell, 2, 0);
                        }
                        var cell = currentCell.PlayGround[currentCell.PosY + 1, currentCell.PosX + 1];
                        if (cell != null && cell.Figure.Colour != currentCell.Figure.Colour && cell.Figure.Colour != Colour.None)
                        {
                            result.AddCell(currentCell, 1, 1);
                        }

                        cell = currentCell.PlayGround[currentCell.PosY + 1, currentCell.PosX - 1];
                        if (cell != null && cell.Figure.Colour != currentCell.Figure.Colour && cell.Figure.Colour != Colour.None)
                        {
                            result.AddCell(currentCell, 1, -1);
                        }
                    }

                    break;
                case FigureType.None:
                    break;
            }

            return result;
        }
    }
}
