using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ChessLib;

namespace ChessTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var pg = new PlayGround();
            pg.ThrowWin += Pg_ThrowWin;

            while (true)
            {
                renderPg(pg);
                try
                {
                    Console.Write("Выберете фигуру(в виде \"n,n\"): ");
                    var posFrom = Console.ReadLine().Split(',').Select(item => int.Parse(item) - 1).ToArray();
                    if (posFrom.Length > 2)
                    {
                        throw new FormatException("Позиция состоит из 2х чисел!");
                    }

                    Console.Write("Выберете позицию, куда переместить(в виде \"n,n\"): ");
                    var posTo = Console.ReadLine().Split(',').Select(item => int.Parse(item) - 1).ToArray();
                    if (posTo.Length > 2)
                    {
                        throw new FormatException("Позиция состоит из 2х чисел!");
                    }

                    pg.Move(pg[posFrom[0], posFrom[1]], pg[posTo[0], posTo[1]]);
                }
                catch(FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            }

        }

        private static void Pg_ThrowWin(Colour obj)
        {
            switch (obj)
            {
                case Colour.White:
                    MessageBox.Show("Победили белые");
                    break;
                case Colour.Black:
                    MessageBox.Show("Победили чёрные");
                    break;
                case Colour.None:
                    break;
            }
        }

        static void renderPg(PlayGround pg)
        {
            Console.Clear();
            Console.Write("Ходят ");
            switch (pg.CurrentPlayer)
            {
                case Colour.White:
                    Console.WriteLine("белые");
                    break;
                case Colour.Black:
                    Console.WriteLine("чёрные");
                    break;
            }
            Console.BackgroundColor = ConsoleColor.Red;
            for (int i = -1; i < pg.VerSize; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.Black;
                if (i != -1)
                {
                    Console.Write($"{i + 1} ");
                }
                else if (i == -1)
                {
                    Console.Write("  ");
                }

                Console.BackgroundColor = ConsoleColor.Red;
                for (int j = 0; j < pg.HorSize; j++)
                {
                    if (i == -1)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(j + 1);
                        continue;
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
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
