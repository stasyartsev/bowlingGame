using BowlingGame.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace BowlingGame.Tests
{
    [TestFixture]
    public class BowlingTests
    {
        private Game game;

        [SetUp]
        public void StartTest()
        {
            game = new Game();
            game.Start();
        }

        [Test]
        public void TestLooserGame()
        {
            for (int roll = 0; roll <= 20; roll++)
                game.Roll(roll, 0);

            Assert.AreEqual(0, game.GetGameScore());
        }

        [Test]
        public void TestPerfectGame()
        {
            for (int roll = 0; roll <= 11; roll++)
                game.Roll(roll,10);

            Assert.AreEqual(300, game.GetGameScore());
        }

        [Test]
        public void TestAllSparesGame()
        {
            for (int roll = 0; roll <= 20; roll++)
                game.Roll(roll, 5);

            Assert.AreEqual(150, game.GetGameScore());
        }

        [Test]
        public void TestNewbieGame()
        {
            for (int roll = 0; roll <= 19; roll++)
                game.Roll(roll, 1);

            Assert.AreEqual(20, game.GetGameScore());
        }

        [Test]
        public void TestRandomGame()
        {
            for (int roll = 0; roll <= 17; roll++)
                game.Roll(roll, 4);

            game.Roll(18, 4);
            game.Roll(19, 6);
            game.Roll(20, 10);

            Assert.AreEqual(92, game.GetGameScore());
        }

        [Test]
        public void TestIncompleteGame()
        {
            game.Roll(0, 4);
            game.Roll(1, 6);
            game.Roll(2, 10);

            Assert.AreEqual(30, game.GetGameScore());
        }

        [Test]
        public void TestExceptionForNegativePins()
        {
            try
            {
                game.Roll(0, -1);
                Assert.Fail("no exception thrown");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.IsTrue(e is ArgumentOutOfRangeException);
            }
        }
        [Test]
        public void TestExceptionForPinsMoreThanTen()
        {
            try
            {
                game.Roll(0, 11);
                Assert.Fail("no exception thrown");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.AreEqual(e.ParamName , "Pins amount may not be negative or more than ten");
            }
        }
    }
}
