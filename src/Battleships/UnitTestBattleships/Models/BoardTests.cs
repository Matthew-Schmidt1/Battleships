using System;
using System.Collections.Generic;
using Battleships.Models;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestBattleships.Models
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void TestBasicConstructor()
        {
            var boardOne = new Board();

            Assert.AreEqual(boardOne.MaxX, 8);
            Assert.AreEqual(boardOne.MaxY, 8);
            Assert.IsTrue(boardOne.Ships.Count == 2);
        }

        [TestMethod]
        public void TestControlledButRandomConstructor()
        {
            var boardOne = new Board(10, 10, 100);

            Assert.AreEqual(boardOne.MaxX, 10);
            Assert.AreEqual(boardOne.MaxY, 10);
            Assert.IsTrue(boardOne.Ships.Count == 100);
        }

        [TestMethod]
        public void TestBoardShot()
        {
            List<Ship> ships = new List<Ship>() { new Ship(new Point2D(0, 1)), new Ship(new Point2D(0, 2)), new Ship(new Point2D(0, 8)) };

            var boardOne = new Board(8, 8, ships);

            var result = boardOne.Shot(new Point2D(8, 0));

            Assert.IsFalse(result.Contains("hot"));
            Assert.IsFalse(result.Contains("warm"));
            Assert.IsTrue(result.Contains("cold"));
            Assert.IsFalse(result.Contains("hit"));
            Assert.IsTrue(boardOne.Ships.Where<Ship>(s => !s.IsDead()).Count() == ships.Count());

            result = boardOne.Shot(new Point2D(0, 0));

            Assert.IsTrue(result.Contains("hot"));
            Assert.IsFalse(result.Contains("warm"));
            Assert.IsTrue(result.Contains("cold"));
            Assert.IsFalse(result.Contains("hit"));
            Assert.IsTrue(boardOne.Ships.Where<Ship>(s => !s.IsDead()).Count() == ships.Count());

            result = boardOne.Shot(new Point2D(1, 4));

            Assert.IsTrue(result.Contains("hot"));
            Assert.IsTrue(result.Contains("warm"));
            Assert.IsFalse(result.Contains("cold"));
            Assert.IsFalse(result.Contains("hit"));
            Assert.IsTrue(boardOne.Ships.Where<Ship>(s => !s.IsDead()).Count() == ships.Count());
        }

        [TestMethod]
        public void TestBoardShotHit()
        {
            List<Ship> ships = new List<Ship>() { new Ship(new Point2D(0, 1)), new Ship(new Point2D(0, 2)), new Ship(new Point2D(0, 8)) };

            var boardOne = new Board(8, 8, ships);

            var result = boardOne.Shot(new Point2D(0, 8));

            Assert.IsFalse(result.Contains("hot"));
            Assert.IsFalse(result.Contains("warm"));
            Assert.IsTrue(result.Contains("cold"));
            Assert.IsTrue(result.Contains("hit"));

            Assert.IsTrue(boardOne.Ships.Where<Ship>(s => !s.IsDead()).Count() == ships.Count() - 1);
        }


        [TestMethod]
        public void TestGameOver()
        {
            List<Ship> ships = new List<Ship>() { new Ship(new Point2D(0, 1)), new Ship(new Point2D(0, 8)) };

            var boardOne = new Board(8, 8, ships);

            boardOne.Shot(new Point2D(0, 8));
            Assert.IsFalse(boardOne.IsGameOver());

            boardOne.Shot(new Point2D(0, 1));
            Assert.IsTrue(boardOne.IsGameOver());
        }



    }
}
