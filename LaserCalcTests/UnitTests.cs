using NUnit.Framework;
using LaserCalcUI;

namespace LaserCalcTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            int test = 1;
        }

        [Test]
        public void ZeroQ()
        {
            int[] testComponentCounts = new int[]{ 1, 1, 1, 1, 1, 1 };
            Laser testLaser = new(testComponentCounts, false, 70, 80);
            testLaser.CalculateLaserStats();

            Assert.AreEqual(12500, testLaser.EnergyStorage);
            Assert.AreEqual(11, testLaser.PumpVolume);
            Assert.AreEqual(12.25f, testLaser.APMod);
            Assert.AreEqual(264, testLaser.DischargeRate);
            Assert.AreEqual(1, testLaser.DoublerCount);
            Assert.AreEqual(1610, testLaser.Cost);
            Assert.AreEqual(26, testLaser.BlockVolume);
            Assert.AreEqual(72.2448959f, testLaser.AP);
            Assert.AreEqual(178.806122f, testLaser.Dps);
            Assert.AreEqual(0.111059703f, testLaser.DpsPerCost);
            Assert.AreEqual(6.87715864f, testLaser.DpsPerVolume);
            Assert.AreEqual(330, testLaser.EnginePower);
        }
    }
}