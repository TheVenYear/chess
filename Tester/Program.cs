﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessLibrary;
using ChessLibrary.Figures;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cell> cells = new List<Cell>();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    cells.Add(new Cell(i, j));
                }
            }

            var huy = new Castle();

            huy.currentCell = cells[3];

            var huyuy = huy.GetMoves(cells).ToList();

            foreach (var item in huyuy)
            {
                Console.WriteLine($"{item.X}, {item.Y}");
            }

        }
    }
}