using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models
{
    public class Ship
    {
        private Point2D Location { get; }
        private bool Dead { get; set; } = false;
        public Ship(Point2D loc)
        {
            this.Location = loc;
        }

        public string Strike(Point2D shot)
        {
            if (Dead) return "";
            var distance = Location.CalucalteDistance(shot);
            if (distance == 0) {
                Dead = true;
                return "hit"; }
            else if (distance <= 2) { return "hot"; }
            else if (distance <= 4) { return "warm"; }
            else  { return "cold"; }
            
        }

        public bool IsDead()
        {
            return Dead;
        }

    }
}
