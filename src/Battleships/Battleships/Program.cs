using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.Models;

namespace Battleships
{
    class Program
    {
        

        Board game;
        static void Main(string[] args)
        {
            var Prog = new Battleship();
            Prog.Setup();
            Prog.StartGame();

            Prog.StartMainLoop();

        }

    }
}
