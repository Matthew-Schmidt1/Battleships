using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Battleships.Models;

namespace UnitTestBattleships.Models
{
    [TestClass]
    public class Point2DTests
    {
        [TestMethod]
        public void DistanceToTest()
        {
            var PointOne = new Point2D(0, 0);
            var PointTwo = new Point2D(0, 2);

            Assert.AreEqual(PointOne.CalucalteDistance(PointTwo), 2);

            PointOne = new Point2D(0, 8);
            PointTwo = new Point2D(8, 0);

            Assert.AreEqual(PointOne.CalucalteDistance(PointTwo), 11);

        }

        [TestMethod]
        public void AreEqualTest()
        {
            var PointOne = new Point2D(0, 0);
            var PointTwo = new Point2D(0, 2);
            var PointThree = new Point2D(0, 0);

            Assert.AreEqual(PointOne, PointThree);
            Assert.AreNotEqual(PointOne, PointTwo);

            Assert.IsTrue(PointOne.GetHashCode() == PointThree.GetHashCode());
            Assert.IsFalse(PointOne.GetHashCode() == PointTwo.GetHashCode());

        }

        [TestMethod]
        public void ToStringTest()
        {
            var PointOne = new Point2D(0, 2);

            Assert.IsTrue(PointOne.ToString().Equals("(0,2)"));
        }
    }
}
