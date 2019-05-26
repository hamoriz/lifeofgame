using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conways_Game_of_Life_cs
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var game = new Game(PentaDecathlon());


            while (true)
            {
                PrintGame(game);
                game.Step();
                Console.ReadLine();
                Console.Clear();
            }
           
        }


        static void PrintGame(Game game)
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (game.IsLivingCell(i,j))
                    {
                        Console.Write('O');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }

        static HashSet<Cell> Toad()
        {
            var cells = new HashSet<Cell>();
            cells.Add(new Cell(10, 10));
            cells.Add(new Cell(11, 10));
            cells.Add(new Cell(12, 10));
            cells.Add(new Cell(9, 11));
            cells.Add(new Cell(10, 11));
            cells.Add(new Cell(11, 11));

            return cells;
            
        }
        
        static HashSet<Cell> PentaDecathlon()
        {
            var cells = new HashSet<Cell>();
            cells.Add(new Cell(10, 10));
            cells.Add(new Cell(11, 10));
         
            cells.Add(new Cell(12, 9));
            cells.Add(new Cell(12, 11));
            
            cells.Add(new Cell(13, 10));
            cells.Add(new Cell(14, 10));
            cells.Add(new Cell(15, 10));
            cells.Add(new Cell(16, 10));
            
            cells.Add(new Cell(17, 9));
            cells.Add(new Cell(17, 11));
            
            cells.Add(new Cell(18, 10));
            cells.Add(new Cell(19, 10));

            return cells;
            
        }
    }  
}
