using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessLib;

namespace ChessTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var pg = new PlayGround();
            var list = pg[1, 0].GetMoves();
            Console.BackgroundColor = ConsoleColor.Red;
            for (int i = 0; i < pg.VerSize; i++)
            {
                for (int j = 0; j < pg.HorSize; j++)
                {
                    if (list.Contains(pg[i, j]))   
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    switch (pg[i, j].Figure.Colour)
                    {
                        case Colour.White:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case Colour.Black:
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case Colour.None:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                    }

                    switch (pg[i, j].Figure.Type)
                    {
                        case FigureType.Castle:
                            Console.Write('C');
                            break;
                        case FigureType.Bishop:
                            Console.Write('B');
                            break;
                        case FigureType.King:
                            Console.Write('w');
                            break;
                        case FigureType.Knight:
                            Console.Write('K');
                            break;
                        case FigureType.Queen:
                            Console.Write('Q');
                            break;
                        case FigureType.Pawn:
                            Console.Write('P');
                            break;
                        case FigureType.None:
                            Console.Write('.');
                            break;
                    }
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                Console.WriteLine();

            }

            Console.ReadKey();
        }
    }
}
