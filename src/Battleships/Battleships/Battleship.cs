using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.Models;

namespace Battleships
{
    class Battleship
    {
        private char[] delimiterChars = { ' ', ',', '.', ':' };

        private int maxX;
        private int maxY;
        private int numberofShips;
        private Board gameBoard;

        private int turn;
        private const int totalNumberofTurns = 20;

        public void StartGame()
        {
            gameBoard = new Board(maxX, maxY, numberofShips);
        }

        public void StartMainLoop()
        {
            if (gameBoard == null) { return; }

            while (!gameBoard.IsGameOver() && turn <= totalNumberofTurns)
            {
                Point2D shot = AskForCalledShot();
                var output = gameBoard.Shot(shot);
                Console.WriteLine(output);
                turn++;
            }

            if (gameBoard.IsGameOver())
            {
                Console.WriteLine("Congratualtions you have won the game.");
            }
            if (turn == totalNumberofTurns && !gameBoard.IsGameOver())
            {
                Console.WriteLine("You have lost the game.");
            }
        }

        private Point2D AskForCalledShot()
        {
            Point2D point = null;
            while (point == null)
            {
                Console.WriteLine($"Please make your {turn+1} shot: X,Y");
                var shot = Console.ReadLine();
                CheckForCommands(shot);
                var coordiantes = shot.Split(delimiterChars);
                int? x = null, y = null;
                if (coordiantes.Length == 2)
                {
                     x = ParseNumber(coordiantes[0]);
                     y = ParseNumber(coordiantes[1]);
                }
                if (x == null || y == null)
                {
                    Console.WriteLine("Something went wrong please input a X and Y as 2,1");
                }
                 else
                {
                    point = new Point2D(x.GetValueOrDefault(), y.GetValueOrDefault());
                }
            }
            return point;
        }

        private void CheckForCommands(string command)
        {
            if(command.Equals("help",StringComparison.OrdinalIgnoreCase)) {
                PrintHelp();
            } 
            else if (command.Equals("quit", StringComparison.OrdinalIgnoreCase)) {
                Environment.Exit(0);
            }
        }

        private void PrintHelp()
        {
           string help = 
                "The aim of the game is to hit all the ships in less than 20 shots." +
                "" +
                "help  =  Prints out this help text." +
                "quit  =  Ends the game.";



            Console.WriteLine(help);
        }

        public void Setup()
        {
            Console.WriteLine("Welcome to battleship");
            Console.WriteLine("Please select the board size.");
            ExtractXAxis();
            ExtractYAxis();
            ExtractNumberofShips();
        }

        private void ExtractNumberofShips()
        {
            int? nShip;
            do
            {
                Console.Write("Please input number of ships. (defautl is 2");
                var str = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(str))
                {
                    numberofShips = 2;
                    return;
                }
                CheckForCommands(str);
                nShip = ParseNumber(str);
                if (nShip != null)
                {
                    Console.WriteLine("This is not a correct value please enter a integer value.");
                }
            } while (nShip != null);
            numberofShips = nShip.GetValueOrDefault();
        }

        private void ExtractXAxis()
        {
            int? xAxis;
            do
            {
                Console.Write("Please input size of X axis: (default is 8)");
                var x = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(x))
                {
                    maxX = 8;
                    return;
                }
                CheckForCommands(x);
                xAxis = ParseNumber(x);
                if (xAxis != null)
                {
                    Console.WriteLine("This is not a correct value please enter a integer value.");
                }
            } while (xAxis != null);
            maxX = xAxis.GetValueOrDefault();
        }

        private void ExtractYAxis()
        {
            int? yAxis;
            do
            {
                Console.Write("Please input size of Y axis: (Default is 8)");
                var y = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(y))
                {
                    maxY = 8;
                    return;
                }
                CheckForCommands(y);
                yAxis = ParseNumber(y);
                if (yAxis != null)
                {
                    Console.WriteLine("This is not a correct value please enter a integer value.");
                }
            } while (yAxis != null);
            maxY = yAxis.GetValueOrDefault();
        }

        private int? ParseNumber(string str)
        {
            int output;
            if (Int32.TryParse(str, out output))
                return output;

            return null;
        }
    }
}
