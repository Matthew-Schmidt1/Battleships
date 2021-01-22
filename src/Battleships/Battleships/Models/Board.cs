using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models
{
    public class Board
    {
        public List<Ship> Ships { get; } = new List<Ship>();

        public int _MaxX { get; } = 8;
        public int _MaxY { get; } = 8;


        public Board()
        {
            
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            
            HashSet<Point2D> Locations = new HashSet<Point2D>();
            for (int i = 0; i < 2; i++)
            {
                if (!Locations.Add(new Point2D(rnd.Next(_MaxX), rnd.Next(_MaxY))))
                {
                    --i;
                }

                if (Locations.Count == 2)
                {
                    break;
                }
            }
            Ships = new List<Ship>();
            foreach (var loc in Locations)
            {
                Ships.Add(new Ship(loc));
            }
        }


        public Board(int maxX, int maxY, int count)
        {
            _MaxX = maxX;
            _MaxY = maxY;
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            HashSet<Point2D> Locations = new HashSet<Point2D>();
            for (int i = 0; i < count; i++)
            {
                if (!Locations.Add(new Point2D(rnd.Next(_MaxX), rnd.Next(_MaxY))))
                {
                    --i;
                }

                if (Locations.Count == count)
                {
                    break;
                }
            }
            Ships = new List<Ship>();
            foreach (var loc in Locations)
            {
                Ships.Add(new Ship(loc));
            }
        }

        public Board(int maxX, int maxY, List<Ship> ships)
        {
            _MaxX = maxX;
            _MaxY = maxY;
            Ships = ships;
        }

        public string Shot(Point2D calledShot)
        {
            StringBuilder hitResult = new StringBuilder();
            StringBuilder afterHitResult = new StringBuilder();
            var aliveShips = Ships.Where<Ship>(s => !s.IsDead()).ToArray();
            for(int i = 0; i<aliveShips.Length; ++i)
            {
                var ship = aliveShips[i];
                var dd = ship.Strike(calledShot);

                hitResult.Append(dd);
                if (dd.Contains("hit"))
                {
                    afterHitResult.AppendLine($"Congratualtions you got a hit with {calledShot}.");
                }
                if (i < aliveShips.Length-1)
                {
                    hitResult.Append(", ");
                }

            }
            hitResult.AppendLine("");

            return hitResult.ToString() + afterHitResult.ToString();
        }
    }
}
