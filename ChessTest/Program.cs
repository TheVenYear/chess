using ChessLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var field = new CellField();

            foreach (var cell in field)
            {
                cell.CurrentFigure = new King();
            }

            var cells = field[2, 2].CurrentFigure.GetMoves(field).Distinct();

            foreach (var item in cells)
            {
                Console.WriteLine($"{item.X}, {item.Y}");
            }

            Console.ReadKey();
        }
    }
}
