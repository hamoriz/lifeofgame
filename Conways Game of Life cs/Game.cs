using System.Collections.Generic;

namespace Conways_Game_of_Life_cs
{
    public class Game
    {
        private HashSet<Cell> cells;


        public Game(HashSet<Cell> cells)
        {
            this.cells = cells;
        }
        
        public bool IsLivingCell(int x, int y)
        {
            return cells.Contains(new Cell(x, y));
        }

        public void Step()
        {
            var newCells = new HashSet<Cell>();
            newCells.UnionWith(ApplyRule2());
            newCells.UnionWith(ApplyRule4());
            cells = newCells;
        }

        private HashSet<Cell> Neighbours(Cell cell)
        {
            var neighbours = new HashSet<Cell>();
            neighbours.Add(new Cell(cell.X, cell.Y + 1));
            neighbours.Add(new Cell(cell.X, cell.Y - 1));
            neighbours.Add(new Cell(cell.X + 1, cell.Y));
            neighbours.Add(new Cell(cell.X - 1, cell.Y));
            neighbours.Add(new Cell(cell.X + 1, cell.Y + 1));
            neighbours.Add(new Cell(cell.X - 1, cell.Y + 1));
            neighbours.Add(new Cell(cell.X + 1, cell.Y - 1));
            neighbours.Add(new Cell(cell.X - 1, cell.Y - 1));
            return neighbours;
        }


        // Minden 2 vagy 3 elo szomszeddal rendelkezo sejt tovabbra is elo marad
        private HashSet<Cell> ApplyRule2()
        {
            // Itt taroljuk azokat a sejteket amik a szabaly alapjan tulelnek
            var survivorCells = new HashSet<Cell>();

            foreach (var cell in cells)
            {
                // A sejt elo szomszedjai
                var livingNeighbours = new HashSet<Cell>(cells);
                livingNeighbours.IntersectWith(Neighbours(cell));

                //Ha 2 vagy 3 elo szomszed, akkor felvesszuk  listara
                if (livingNeighbours.Count == 2 || livingNeighbours.Count == 3) survivorCells.Add(cell);
            }

            return survivorCells;
        }


        private HashSet<Cell> ApplyRule4()
        {
            //Megkeressuk, milyen halott cellakat vizsgaljunk meg
            var deadCells = new HashSet<Cell>();

            foreach (var cell in cells) deadCells.UnionWith(Neighbours(cell));

            deadCells.ExceptWith(cells);

            // Most megvan kiket kell vizsgalni, hogy feltamaszthato e


            // Itt taroljuk, kik tamadjanak fel

            var cellsToResurrect = new HashSet<Cell>();
            foreach (var cell in deadCells)
            {
                var livingNeighbours = new HashSet<Cell>(Neighbours(cell));
                livingNeighbours.IntersectWith(cells);

                //Ha 3 elo szomszed, akkor felvesszuk  listara
                if (livingNeighbours.Count == 3) cellsToResurrect.Add(cell);
            }

            return cellsToResurrect;
        }
    }
}