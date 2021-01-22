using System;
using Battleships.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestBattleships.Models
{
    [TestClass]
    public class ShipTests
    {
        [TestMethod]
        public void TestColdStrike()
        {
            var pointOne = new Point2D(0, 0);
            var ship = new Ship(pointOne);

            Assert.AreEqual(ship.Strike(new Point2D(0, 6)), "cold");
            Assert.AreEqual(ship.Strike(new Point2D(0, 5)), "cold");
        }

        [TestMethod]
        public void TestWarmStrike()
        {
            var pointOne = new Point2D(0, 0);
            var ship = new Ship(pointOne);


            Assert.AreEqual(ship.Strike(new Point2D(0, 4)), "warm");
            Assert.AreEqual(ship.Strike(new Point2D(0, 3)), "warm");


        }

        [TestMethod]
        public void TestHotStrike()
        {
            var pointOne = new Point2D(0, 0);
            var ship = new Ship(pointOne);


            Assert.AreEqual(ship.Strike(new Point2D(0, 2)), "hot");
            Assert.AreEqual(ship.Strike(new Point2D(0, 1)), "hot");

        }

        [TestMethod]
        public void TestHitStrike()
        {
            var pointOne = new Point2D(0, 0);
            var ship = new Ship(pointOne);
            Assert.AreEqual(ship.Strike(new Point2D(0, 0)), "hit");

            Assert.IsTrue(ship.IsDead());

        }
    }
}
