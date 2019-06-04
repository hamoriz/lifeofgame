using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


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

            List<Cell> cells = new List<Cell>();
            cells.Add(new Cell(10, 10));
            cells.Add(new Cell(11, 10));
            cells.Add(new Cell(12, 10));
            cells.Add(new Cell(9, 11));
            cells.Add(new Cell(10, 11));
            cells.Add(new Cell(11, 11));

            
            Console.ReadLine();
            PrintGame(cells);
            var newCells = ApplyRule4(cells);
            Console.ReadLine();
            while (true)
            {
                PrintGame(newCells);
                newCells = ApplyRule4(newCells);
                Console.ReadLine();
                Console.Clear();
            }
            
           

        }



        static List<Cell> ApplyRule4(List<Cell> currentCells)
            {
                List<Cell> neighbours = new List<Cell>();

                foreach (Cell cell in currentCells)
                {
                    List<Cell> cellNeighbours= MyNeighbours(cell);
                    
                    neighbours.AddRange(cellNeighbours);
                }

                
                List<Cell> deadCells = new List<Cell>();
                foreach (Cell cell in neighbours)
                {
                    if (!currentCells.Contains(cell))
                    {
                        deadCells.Add(cell);
                    }
                }


                List<Cell> resurrectCells = new List<Cell>();
                foreach (Cell cell in deadCells)
                {
                    List<Cell> deadCellNeighbours = MyNeighbours(cell);

                    int livingCellCounter = 0;
                    
                    foreach (Cell neighbour in deadCellNeighbours)
                    {
                        if (currentCells.Contains(neighbour))
                        {
                            livingCellCounter++;
                        }
                    }

                    if (livingCellCounter == 3)
                    {
                        resurrectCells.Add(cell);  
                    }
                }

                return resurrectCells;
            }


        static List<Cell> MyNeighbours(Cell cell)
        {
            List<Cell> neighbours = new List<Cell>();
            neighbours.Add(new Cell(cell.X,cell.Y+1));
            neighbours.Add(new Cell(cell.X,cell.Y-1));
            neighbours.Add(new Cell(cell.X-1,cell.Y));
            neighbours.Add(new Cell(cell.X+1,cell.Y));
            
            neighbours.Add(new Cell(cell.X+1,cell.Y+1));
            neighbours.Add(new Cell(cell.X+1,cell.Y-1));
            neighbours.Add(new Cell(cell.X-1,cell.Y+1));
            neighbours.Add(new Cell(cell.X-1,cell.Y-1));
            return neighbours;
        }

        static void PrintGame(List<Cell> cells)
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (cells.Contains(new Cell(i,j)))
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

        static List<Cell> Toad()
        {
            var cells = new List<Cell>();
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
