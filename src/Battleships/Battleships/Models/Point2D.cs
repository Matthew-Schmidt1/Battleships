using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models
{
    public class Point2D : IEquatable<Point2D>
    {
        private int X { get; set; }
        private int Y { get; set; }

        public override string ToString()
        {
            return $"({X},{Y})";
        }

        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int CalucalteDistance(Point2D other)
        {
            // changed from  (x1 - x2) + (y1 - y2) = distancce, as this does work for 
            // http://mathsfirst.massey.ac.nz/Algebra/PythagorasTheorem/pythapp.htm


            return (int) Math.Round(Math.Sqrt(Math.Pow(X - other.X,2) + Math.Pow(Y - other.Y,2)));
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Point2D);
        }

        public bool Equals(Point2D other)
        {
            return other != null &&
                   X == other.X &&
                   Y == other.Y;
        }

        public override int GetHashCode()
        {
            int hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
    }
}
